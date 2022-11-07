import { Component, OnInit } from "@angular/core";

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
