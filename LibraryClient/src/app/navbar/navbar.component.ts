import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router:Router) { }

  jwt:string|null;

  ngOnInit(): void {
    this.jwt = localStorage.getItem("token");
  }

  logOut(): void{
    localStorage.removeItem("token");
    this.router.navigate(["/signInUp"]).then(()=>{
      window.location.reload();
    });
  }

}
