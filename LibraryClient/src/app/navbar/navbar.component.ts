import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IUserDto } from "src/Dtos/User/IUserDto";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styleUrls: ["./navbar.component.css"],
})
export class NavbarComponent implements OnInit {
  constructor(private router: Router) {}

  user: IUserDto | null;
  jwt: string | null;
  ngOnInit(): void {
    let u = localStorage.getItem("user");
    
    if (u !== null) this.user = JSON.parse(u);
    else this.user = null;

    this.jwt = localStorage.getItem("token");
  }

  logOut(): void {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    this.router.navigate(["/signInUp"]).then(() => {
      window.location.reload();
    });
  }
}
