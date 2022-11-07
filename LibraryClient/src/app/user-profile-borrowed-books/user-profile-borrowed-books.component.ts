import { Component, OnInit } from '@angular/core';
import { IBookRatingAddDto } from 'src/Dtos/BookRating/IBookRatingAddDto';
import { IBookRatingDto } from 'src/Dtos/BookRating/IBookRatingDto';
import { IBookRatingRemoveDto } from 'src/Dtos/BookRating/IBookRatingRemoveDto';
import { IBookRatingUpdateDto } from 'src/Dtos/BookRating/IBookRatingUpdateDto';
import { IBorrowedBookDto } from 'src/Dtos/BorrowedBook/IBorrowedBookDto';
import { BookRatingServices } from 'src/services/bookRatingServices';
import { BorrowingBookService } from 'src/services/borrowingBookServices';
import { ExtraFunctions } from 'src/services/extraFunctions';

@Component({
  selector: 'app-user-profile-borrowed-books',
  templateUrl: './user-profile-borrowed-books.component.html',
  styleUrls: ['./user-profile-borrowed-books.component.css']
})
export class UserProfileBorrowedBooksComponent implements OnInit {

  constructor(    private borrowingBookService: BorrowingBookService,
    private bookRatingService: BookRatingServices,
    public extraFunctions: ExtraFunctions) { }


    borrowedBooks: IBorrowedBookDto[];
    bookRatings: IBookRatingDto[];
    page: number = 1;
  
    //p-dialog
    bookRatingDialog: boolean;
    submitted: boolean;
    isNotExist: boolean;
    bookId: number;
    borrowedBookId: number;
    bookRating: IBookRatingDto;

  ngOnInit(): void {
    this.borrowingBookService.getBorrowedBooksByUser().subscribe((resp) => {
      this.borrowedBooks = resp;
    });
    this.bookRatingService.getBookRatingsByUser().subscribe((resp) => {
      this.bookRatings = resp;
    });
  }

  
  borrowBook(id: number) {
    this.borrowingBookService.renewBook(id).subscribe({
      next: (resp) => {
        this.borrowedBooks[
          this.borrowedBooks.findIndex((x) => x.id === id)
        ].isRenew = true;
      },
      error: (error) => {
        if (error === "This was already renewed") {
          this.extraFunctions.showToast("error", "Błąd", "Ta książka była już przedłużana");
        }
        if (error === "This book is not ready yet") {
          this.extraFunctions.showToast("warn", "Info", "Książka nie jest jeszcze gotowa");
        }
      },
    });
  }

  getDate(date: string): string {
    return date.slice(0, 9);
  }
  //p-dialog
  editRating(bookId: number, borrowedBookId: number) {
    this.submitted = false;
    let bookR =
      this.bookRatings[this.bookRatings.findIndex((x) => x.book?.id == bookId)];

    this.bookRating = { ...bookR };
    if (Object.keys(this.bookRating).length === 0) {
      this.isNotExist = true;
      this.bookId = bookId;
    } else {
      this.isNotExist = false;
    }
    this.borrowedBookId = borrowedBookId;

    this.bookRatingDialog = true;
  }
  hideDialog(): void {
    this.bookRatingDialog = false;
    this.submitted = false;
  }
  saveRating(): void {
    this.submitted = true;
    if (this.isNotExist) {
      //add
      let newRating: IBookRatingAddDto = {
        bookId: this.bookId,
        comment: this.bookRating.comment,
        rating: this.bookRating.rating,
      };
      this.bookRatingService.addBookRating(newRating).subscribe({
        next: (resp) => {
          this.bookRatings.push(resp);
          this.borrowedBooks[
            this.borrowedBooks.findIndex((x) => x.book?.id == resp.book?.id)
          ].isRated = true;
          this.bookRatingDialog = false;
        },
        error: (error) => {
          if (error === "You must read it first.") {
            this.extraFunctions.showToast("error", "Błąd", "Najpierw musisz oddać książke.");
          }
          if (error === "You rated it before.") {
            this.extraFunctions.showToast("warn", "Info", "Oceniłeś już tą książke");
          }
        },
      });
    } else {
      //update
      let updateRating: IBookRatingUpdateDto = {
        id: this.bookRating.id,
        bookId: this.bookRating.book?.id!,
        comment: this.bookRating.comment,
        rating: this.bookRating.rating,
      };
      this.bookRatingService.updateBookRating(updateRating).subscribe({
        next: (resp) => {
          this.bookRatings[
            this.bookRatings.findIndex((x) => x.id == this.bookRating.id)
          ] = resp;
          this.bookRatingDialog = false;
        },
        error: (error) => {
          if (error === "This rating do not belong to you.") {
            this.extraFunctions.showToast("error", "Błąd", "To nie twoja ocena.");
          }
        },
      });
    }
  }
  deleteRating(): void {
    if (this.isNotExist) {
      this.extraFunctions.showToast("error", "Błąd", "Musisz najpierw dodać ocene.");
    } else {
      let ratingToDelete: IBookRatingRemoveDto = {
        id: this.bookRating.id,
        borrowedBookId: this.borrowedBookId,
      };
      this.bookRatingService.deleteBookRating(ratingToDelete).subscribe({
        next: (resp) => {
          this.bookRatings = this.bookRatings.filter((x) => x.id != resp.id);
          this.borrowedBooks[
            this.borrowedBooks.findIndex((x) => x.book?.id == resp.book?.id)
          ].isRated = false;
          this.bookRatingDialog = false;
        },
        error: (error) => {
          if (error === "This rating do not belong to you.") {
            this.extraFunctions.showToast("error", "Błąd", "To nie twoja ocena.");
          }
        },
      });
    }
  }
  cancel(borrowedBookId:number):void{
    this.borrowingBookService.cancelBook(borrowedBookId).subscribe({next:(resp)=>{
      this.borrowedBooks = this.borrowedBooks.filter(x=>x.id !=resp.id);
    },error:(error)=>{
      if (error === "You can't cancel") {
        this.extraFunctions.showToast("error", "Błąd", "Nie można już anulować wypożyczenia książki");
      }
    }})
  }

}
