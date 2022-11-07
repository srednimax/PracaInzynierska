import { Component, OnInit } from "@angular/core";

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
