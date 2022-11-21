import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IBookDto } from "src/Dtos/Book/IBookDto";
import { IGenreDto } from "src/Dtos/Genre/IGenreDto";
import { BookService } from "src/services/bookService";
import { BorrowingBookService } from "src/services/borrowingBookServices";
import { ExtraFunctions } from "src/services/extraFunctions";
import { GenreService } from "src/services/genreService";

@Component({
  selector: "app-books",
  templateUrl: "./books.component.html",
  styleUrls: ["./books.component.css"],
})
export class BooksComponent implements OnInit {
  constructor(
    private bookService: BookService,
    private borrowingBookService: BorrowingBookService,
    public extraFunctions:ExtraFunctions,
    private genreService:GenreService
  ) {}

  books: IBookDto[];
  filterBooks: IBookDto[];
  page: number = 1;
  search:string;
  from:string;
  to:string;
  isAvalible:boolean;
  
  genres:IGenreDto[];
  selectedGenres:IGenreDto[]=[];


  ngOnInit(): void {
    this.bookService.getBooks().subscribe((resp) => {
      this.books = resp;
      this.filterBooks = resp;
    });
    this.genreService.getAll().subscribe(resp=>{
      this.genres=resp
    })
  }
  borrowBook(id: number) {
    this.borrowingBookService.borrowBooks(id).subscribe({
      next: (resp) => {
        this.books[this.books.findIndex((x) => x.id === id)].isBorrowed = true;
        this.filterBooks[this.filterBooks.findIndex((x) => x.id === id)].isBorrowed = true;
      },
      error: (error) => {
        if (error === "You must first pay the penalty") {
          this.extraFunctions.showToast("error", "Błąd", "Musisz najpierw zapłacić karę.");
        }
        if (error === "You already booked this book") {
          this.extraFunctions.showToast(
            "info",
            "Informacja",
            "Książka jest już w trakcie realizacji."
          );
        }
        if (error === "You can't borrowed more than 3 books at the same time") {
          this.extraFunctions.showToast(
            "error",
            "Błąd",
            "Nie możesz wypożyczyć więcej niż 3 książki naraz."
          );
        }
      },
    });
  }
  
  filterText(){
    if(this.search)
    {
      this.filterBooks=this.books.filter(x=>x.title?.includes(this.search));
    }
  }

 
  

 
}
