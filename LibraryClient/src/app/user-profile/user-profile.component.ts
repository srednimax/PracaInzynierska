import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-user-profile",
  templateUrl: "./user-profile.component.html",
  styleUrls: ["./user-profile.component.css"],
})
export class UserProfileComponent implements OnInit {
  constructor() {}

  tabSettings: boolean;
  tabBooks: boolean;
  tabRecommendations: boolean;

  ngOnInit(): void {
    this.tabSettings = true;
  }

  changeTab(tab: string): void {
    this.tabSettings = false;
    this.tabBooks = false;
    this.tabRecommendations = false;
    switch (tab) {
      case "set":
        this.tabSettings = true;
        break;
      case "book":
        this.tabBooks = true;
        break;
      case "rec":
        this.tabRecommendations = true;
        break;
    }
  }
}
