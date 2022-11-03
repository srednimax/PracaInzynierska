import { Component, OnInit } from "@angular/core";
import { IBorrowedBookChangeStatusDto } from "src/Dtos/BorrowedBook/IBorrowedBookChangeStatus";
import {
  IBorrowedBookDto,
  IStatus,
} from "src/Dtos/BorrowedBook/IBorrowedBookDto";
import { IBorrowedBookReturnDto } from "src/Dtos/BorrowedBook/IBorrowedBookReturnDto";
import { BorrowingBookService } from "src/services/borrowingBookServices";
import { ExtraFunctions } from "src/services/ExtraFunctions";

@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"],
})
export class EmployeeComponent implements OnInit {
  constructor(
    private borrowingBookService: BorrowingBookService,
    public extraFunctions: ExtraFunctions
  ) {}

  borrowedBooks: IBorrowedBookDto[];
  page: number = 1;

  //p-dialog
  borrowedBookDialog: boolean;
  submitted: boolean;
  bookId: number;
  borrowedBookId: number;
  borrowedBook: IBorrowedBookDto;
  status: IStatus[] = [
    { number: 0, name: "Zamówiona" },
    { number: 1, name: "Zarezerwowane" },
    { number: 2, name: "W trakcie realizacji" },
    { number: 3, name: "Gotowe do obioru" },
    { number: 4, name: "Odebrana" },
    { number: 5, name: "Oddana" },
    { number: 6, name: "Anuluj" },
  ];
  selectedStatus: number;

  ngOnInit(): void {
    this.borrowingBookService.getBorrowedBooks().subscribe((resp) => {
      this.borrowedBooks = resp;
    });
  }

  hideDialog(): void {
    this.borrowedBookDialog = false;
  }

  save(): void {
    if (this.selectedStatus === 5) {
      let data: IBorrowedBookReturnDto = {
        borrowedBookId: this.borrowedBook.id,
      };
      this.borrowingBookService.returnBook(data).subscribe({
        next: (resp) => {
          this.borrowedBooks[
            this.borrowedBooks.findIndex((x) => x.id == resp.id)
          ] = resp;
          this.borrowedBookDialog = false;
          this.extraFunctions.showToast(
            "success",
            "sukces",
            "Pomyślna zmiana statusu"
          );
        },
        error: (error) => {
          if (error === "This book was already returned") {
            this.extraFunctions.showToast(
              "error",
              "Błąd",
              "Ta książka zostałą już zwrócona"
            );
          }
          if (error === "This book has not been received yet") {
            this.extraFunctions.showToast(
              "error",
              "Błąd",
              "Ta książka nie została jescze odebrana"
            );
          }
        },
      });
    } else {
      let data: IBorrowedBookChangeStatusDto = {
        borrowedBookId: this.borrowedBook.id,
        status: this.selectedStatus,
      };
      this.borrowingBookService.changeStatus(data).subscribe({
        next: (resp) => {
          this.borrowedBooks[
            this.borrowedBooks.findIndex((x) => x.id == resp.id)
          ] = resp;
          this.borrowedBookDialog = false;
          this.extraFunctions.showToast(
            "success",
            "sukces",
            "Pomyślna zmiana statusu"
          );
        },
        error: (error) => {
          if (error === "Can't change returned book's status") {
            this.extraFunctions.showToast(
              "error",
              "Błąd",
              "Ta książka zostałą już zwrócona"
            );
          }
          if (error === "This book has not been received yet") {
            this.extraFunctions.showToast(
              "error",
              "Błąd",
              "Ta książka nie została jescze odebrana"
            );
          }
        },
      });
    }
  }

  editStatus(id: number) {
    this.submitted = false;

    let bookR =
      this.borrowedBooks[this.borrowedBooks.findIndex((x) => x.id == id)];

    this.borrowedBook = { ...bookR };
    this.selectedStatus=this.borrowedBook.status;
    this.borrowedBookDialog = true;
  }
}
