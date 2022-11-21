import { Component, OnInit, ViewChild } from "@angular/core";
import { ConfirmationService } from "primeng/api";
import { Table } from "primeng/table";
import { IGenreDto } from "src/Dtos/Genre/IGenreDto";
import { IBookAddDto } from "src/Dtos/Book/IBookAddDto";
import { IBookDto} from "src/Dtos/Book/IBookDto";
import { IBookUpdateDto } from "src/Dtos/Book/IBookUpdateDto";
import { BookService } from "src/services/bookService";
import { ExtraFunctions } from "src/services/extraFunctions";
import { GenreService } from "src/services/genreService";

@Component({
  selector: "app-employee-books",
  templateUrl: "./employee-books.component.html",
  styleUrls: ["./employee-books.component.css"],
})
export class EmployeeBooksComponent implements OnInit {
  constructor(
    private bookService: BookService,
    public extraFunctions: ExtraFunctions,
    private confirmationService: ConfirmationService,
    private genreService: GenreService
  ) {}

  books: IBookDto[];
  book: IBookDto;
  bookAdd:IBookAddDto={
    title:"",
    author:"",
    genres:[],
    publishYear:2022
  };
  genres:IGenreDto[];

  bookDialog: boolean;
  bookDialogAdd: boolean;
  submitted: boolean;
  submittedAdd: boolean;

  @ViewChild("dt") dt: Table | undefined;

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((resp) => {
      this.books = resp;
    });
    this.genreService.getAll().subscribe(resp=>{
      this.genres = resp;
    })
  }
  editBook(book: IBookDto): void {
    this.book = { ...book };
    this.bookDialog = true;
  }
  deleteBook(book: IBookDto): void {
    this.confirmationService.confirm({
      message: "Czy napewno chcesz usunąć książke?",
      header: "Potwierdzenie",
      icon: "pi pi-exclamation-triangle",
      acceptLabel: "Tak",
      rejectLabel: "Nie",
      accept: () => {
        this.bookService.deleteBook(book.id).subscribe({
          next: (resp) => {
            this.books = this.books.filter((x) => x.id !== resp.id);
            this.extraFunctions.showToast(
              "success",
              "Sukces",
              "Udało się usunąć książke."
            );
          },
          error: (error) => {
            if (error === "Can't remove borrowed book") {
              this.extraFunctions.showToast(
                "error",
                "Błąd",
                "Nie można usunąć pożyczonej książki"
              );
            }
          },
        });
      },
    });
  }

  hideDialog(): void {
    this.bookDialog = false;
    this.submitted = false;
  }

  saveBook(): void {
    this.submitted=true;
    let data:IBookUpdateDto={
      id: this.book.id,
      title: this.book.title,
      author: this.book.author,
      genres: this.book.genres,
      publishYear: this.book.publishYear
    }

    this.bookService.updateBook(data).subscribe({next:resp=>{
      this.books[this.books.findIndex((x) => x.id == resp.id)] = resp;
      this.extraFunctions.showToast(
        "success",
        "Sukces",
        "Udało się zaktualizować książke."
      );
      this.bookDialog=false;
    },error:error=>{
      if (error === "Can't update borrowed book") {
        this.extraFunctions.showToast(
          "error",
          "Błąd",
          "Nie można usunąć pożyczonej książki"
        );
      }
    }})

  }

  addBook():void{
    this.submittedAdd=false;
    this.bookDialogAdd=true;
  } 

  hideDialogAdd(): void {
    this.bookDialogAdd = false;
    this.submittedAdd = false;
  }
  saveBookAdd():void{
    this.submittedAdd=true;
    this.bookService.addBook(this.bookAdd).subscribe(resp=>{
      this.books.push(resp);
      this.extraFunctions.showToast(
        "success",
        "Sukces",
        "Udało się dodać książke."
      );
      this.bookAdd.title="";
      this.bookAdd.author="";
      this.bookAdd.genres=[];
      this.bookAdd.publishYear=2022;
      this.bookDialogAdd=false;
      
    })
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
