import { Component, OnInit } from "@angular/core";
import { IBookDto } from "src/Dtos/Book/IBookDto";
import { BookService } from "src/services/bookService";
import { BorrowingBookService } from "src/services/borrowingBookServices";
import { ExtraFunctions } from "src/services/extraFunctions";

@Component({
  selector: "app-user-profile-recomendation",
  templateUrl: "./user-profile-recomendation.component.html",
  styleUrls: ["./user-profile-recomendation.component.css"],
})
export class UserProfileRecomendationComponent implements OnInit {
  constructor(
    private bookService: BookService,
    public extraFunctions: ExtraFunctions,
    private borrowingBookService: BorrowingBookService
  ) {}

  books: IBookDto[];
  page: number = 1;
  isAvalible:boolean;

  ngOnInit(): void {
    this.bookService.getRecommendedBooks().subscribe((resp) => {
      this.books = resp;
    });
  }

  borrowBook(id: number) {
    this.borrowingBookService.borrowBooks(id).subscribe({
      next: (resp) => {
        this.books[this.books.findIndex((x) => x.id === id)].isBorrowed = true;
        // this.filterBooks[
        //   this.filterBooks.findIndex((x) => x.id === id)
        // ].isBorrowed = true;
      },
      error: (error) => {
        if (error === "You must first pay the penalty") {
          this.extraFunctions.showToast(
            "error",
            "Błąd",
            "Musisz najpierw zapłacić karę."
          );
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
}
