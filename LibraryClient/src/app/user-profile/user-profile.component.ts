import { Component, OnInit } from "@angular/core";
import { IBookRatingDto } from "src/Dtos/BookRating/IBookRatingDto";
import { IBorrowedBookDto } from "src/Dtos/BorrowedBook/IBorrowedBookDto";
import { BookRatingServices } from "src/services/bookRatingServices";
import { BorrowingBookService } from "src/services/borrowingBookServices";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.css"],
})
export class UserProfileComponent implements OnInit {
  constructor(private borrowingBookService: BorrowingBookService,private bookRatingService: BookRatingServices) {}

  borrowedBooks: IBorrowedBookDto[];
  bookRatings:IBookRatingDto[];
  bookRating:IBookRatingDto;

  //p-dialog
  bookRatingDialog: boolean;
  submitted:boolean;

  ngOnInit(): void {
    this.borrowingBookService.getBorrowedBooks().subscribe((resp) => {
      this.borrowedBooks = resp;
    });
    this.bookRatingService.getBookRatingsByUser().subscribe(resp =>{
      this.bookRatings = resp;
    })
  }

  con() {
    console.log(this.borrowedBooks);
  }
  borrowBook(id: number) {
    this.borrowingBookService.renewBook(id).subscribe({
      next: (resp) => {
        this.borrowedBooks[
          this.borrowedBooks.findIndex((x) => x.id === id)
        ].isRenew = true;
      },
      error: (error) => {
        // if (error === "You must first pay the penalty") {
        //   this.showToast("error", "Błąd", "Musisz najpierw zapłacić karę.");
        // }
        // if (error === "You already booked this book") {
        //   this.showToast(
        //     "info",
        //     "Informacja",
        //     "Książka jest już w trakcie realizacji."
        //   );
        // }
        // if (error === "You can't borrowed more than 3 books at the same time") {
        //   this.showToast(
        //     "error",
        //     "Błąd",
        //     "Nie możesz wypożyczyć więcej niż 3 książki naraz."
        //   );
        // }
      },
    });
  }
  genre(gen: number): string {
    switch (gen) {
      case 0:
        return "Fikcja literacka";
      case 1:
        return "Kryminał";
      case 2:
        return "Horror";
      case 3:
        return "Historyczna";
      case 4:
        return "Romans";
      case 5:
        return "Western";
      case 6:
        return "Science fiction";
      case 7:
        return "Fantasy";
      default:
        return "";
    }
  }
  getDate(date:string):string{
    return date.slice(0, 9);
  }
  status(stat: number): string {
    switch (stat) {
      case 0:
        return "Zamówiona";
      case 1:
        return "Zarezerwowane";
      case 2:
        return "W trakcie realizacji";
      case 3:
        return "Gotowe do obioru";
      case 4:
        return "Odebrana";
      case 5:
        return "Oddana";
      default:
        return "";
    }
  }

  //p-dialog
  editRating(bookId:number) {
    let bookR = this.bookRatings[this.bookRatings.findIndex(x=>x.book?.id == bookId)]
    
    this.bookRating = {...bookR};
    this.bookRatingDialog = true;
  }
  hideDialog():void{
    this.bookRatingDialog = false;
    this.submitted = false;
  }
  saveRating(): void
  {

  }
  deleteRating(): void{

  }
}
