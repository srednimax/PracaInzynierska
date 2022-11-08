import { Component, OnInit } from '@angular/core';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { ExtraFunctions } from 'src/services/extraFunctions';
import { UserService } from 'src/services/userService';

@Component({
  selector: 'app-user-profile-penalty',
  templateUrl: './user-profile-penalty.component.html',
  styleUrls: ['./user-profile-penalty.component.css']
})
export class UserProfilePenaltyComponent implements OnInit {

  constructor(private userService:UserService,private extraFunctions:ExtraFunctions) { }

  user:IUserDto;

  ngOnInit(): void {
    this.userService.getUser().subscribe(resp=>{
      this.user=resp;
    })
  }

  pay(){
    this.userService.payPenalty().subscribe({next:resp=>{
      this.user=resp;
      this.extraFunctions.showToast("success", "Sukces", "Płatność zatwierdzona");
    },error:error=>{
      if (error === "You do not need to pay") {
        this.extraFunctions.showToast("info", "Info", "Nie masz żadnych zaległych kar.");
      }
    }})
  }

}
