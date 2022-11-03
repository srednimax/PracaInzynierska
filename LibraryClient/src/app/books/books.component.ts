import { Component, OnInit } from "@angular/core";
import { MessageService } from "primeng/api";
import { IBookDto } from "src/Dtos/Book/IBookDto";
import { BookService } from "src/services/bookService";
import { BorrowingBookService } from "src/services/borrowingBookServices";
import { ExtraFunctions } from "src/services/ExtraFunctions";

@Component({
  selector: "app-books",
  templateUrl: "./books.component.html",
  styleUrls: ["./books.component.css"],
})
export class BooksComponent implements OnInit {
  constructor(
    private bookService: BookService,
    private borrowingBookService: BorrowingBookService,
    public extraFunctions:ExtraFunctions
  ) {}

  books: IBookDto[];
  filterBooks: IBookDto[];
  page: number = 1;
  search:string;
  from:string;
  to:string;
  isAvalible:boolean;
  
  genres:any[] =[
    {id:0,genre:"Fikcja literacka"},
    {id:1,genre:"Kryminał"},
    {id:2,genre:"Horror"},
    {id:3,genre:"Historyczna"},
    {id:4,genre:"Romans"},
    {id:5,genre:"Western"},
    {id:6,genre:"Science fiction"},
    {id:7,genre:"Fantasy"}
      ];
  selectedGenres:any[]=[];


  ngOnInit(): void {
    this.bookService.getBooks().subscribe((resp) => {
      this.books = resp;
      this.filterBooks = resp;
    });
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
