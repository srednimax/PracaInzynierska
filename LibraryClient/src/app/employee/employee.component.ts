import { Component, OnInit } from "@angular/core";
import { IBorrowedBookDto } from "src/Dtos/BorrowedBook/IBorrowedBookDto";
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

  ngOnInit(): void {
    this.borrowingBookService.getBorrowedBooks().subscribe((resp) => {
      this.borrowedBooks = resp;
    });
  }
}
