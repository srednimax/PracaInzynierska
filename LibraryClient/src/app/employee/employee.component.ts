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
  tabSettings: boolean;

  constructor() {}

  ngOnInit(): void {
    this.tabSettings = true;
  }

  changeTab(tab: string): void {
    switch (tab) {
      case "set":
        this.tabSettings = true;
        break;
      case "book":
        this.tabSettings = false;
        break;
    }
  }
}
