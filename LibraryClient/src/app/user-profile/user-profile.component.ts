import { Component, OnInit } from "@angular/core";
import { MessageService } from "primeng/api";
import { IBookRatingAddDto } from "src/Dtos/BookRating/IBookRatingAddDto";
import { IBookRatingDto } from "src/Dtos/BookRating/IBookRatingDto";
import { IBookRatingRemoveDto } from "src/Dtos/BookRating/IBookRatingRemoveDto";
import { IBookRatingUpdateDto } from "src/Dtos/BookRating/IBookRatingUpdateDto";
import { IBorrowedBookDto } from "src/Dtos/BorrowedBook/IBorrowedBookDto";
import { BookRatingServices } from "src/services/bookRatingServices";
import { BorrowingBookService } from "src/services/borrowingBookServices";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.css"],
})
export class UserProfileComponent implements OnInit {
  constructor() {}

  tabSettings: boolean;

  ngOnInit(): void {
    this.tabSettings = true;
    
  }

  changeTab(tab: string): void {
    
    switch (tab) {
      case "set":
        this.tabSettings =true;
        break;
      case "book":
        this.tabSettings=false;
        break;
    }
  }

}
