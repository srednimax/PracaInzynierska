import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"],
})
export class EmployeeComponent implements OnInit {
  tabBooks: boolean;
  tabBorrowedBooks: boolean;
  tabGenre: boolean;

  constructor() {}

  ngOnInit(): void {
    this.tabBorrowedBooks = true;
  }

  changeTab(tab: string): void {
   this.tabBooks= false;
   this.tabBorrowedBooks=false;
   this.tabGenre=false;
    switch (tab) {
      case "bor":
        this.tabBorrowedBooks = true;
        break;
      case "book":
        this.tabBooks = true;
        break;
        case "genre":
          this.tabGenre = true;
          break;
    }
  }
}
