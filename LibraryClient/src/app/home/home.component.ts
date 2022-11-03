import { Component, OnInit } from '@angular/core';
import { IUserDto } from 'src/Dtos/User/IUserDto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  user:IUserDto|null;

  ngOnInit(): void {
    let u = localStorage.getItem("user");
    
    if (u !== null) this.user = JSON.parse(u);
    else this.user = null;
  }

}
