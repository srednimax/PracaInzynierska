import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { IGender, IUserSignUpDto } from 'src/Dtos/User/IUserSignUpDto';
import { UserService } from 'src/services/userService';
import { CustomValidators } from '../customValidators/customValidators';

@Component({
  selector: 'app-user-profile-update',
  templateUrl: './user-profile-update.component.html',
  styleUrls: ['./user-profile-update.component.css']
})
export class UserProfileUpdateComponent implements OnInit {


  user:IUserDto;

  loginForm = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.email]),
    firstName: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z]{3,50}$")]),
    lastName: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z]{3,50}$")]),
    phoneNumber: new FormControl('',[Validators.required,Validators.required,Validators.pattern("^[1-9][0-9]{8,8}$")]),
    birth: new FormControl('',[Validators.required]),
    gender: new FormControl('',[Validators.required]),
  });

  existEmail:boolean;
  genders : IGender[] = [{number:0,name:'wole nie podawać'},{number:1,name:'mężczyzna'},{number:2,name:'kobieta'}];

  constructor(private userService:UserService) { }

  ngOnInit( ): void {
    this.userService.getUser().subscribe(resp =>{
      this.user=resp;
      this.email?.setValue(this.user.email);
      this.firstName?.setValue(this.user.firstName);
      this.lastName?.setValue(this.user.lastName);
      this.phoneNumber?.setValue(this.user.phoneNumber);
      this.birth?.setValue(this.user.birth);
      this.gender?.setValue(this.user.gender);
    })
    
  }

  onSubmit(): void{
    this.existEmail = false;

    let userSignUp : IUserSignUpDto ={
      email: this.loginForm.controls.email.value,
      password: "this.loginForm.controls.password.value",
      confirmPassword:"",
      firstName: this.loginForm.controls.firstName.value,
      lastName: this.loginForm.controls.lastName.value,
      phoneNumber: this.loginForm.controls.phoneNumber.value,
      birth: this.loginForm.controls.birth.value,
      gender: this.loginForm.controls.gender.value
    };
    this.userService.signUpUser(userSignUp).subscribe(
      {next: (resp) =>{
      },
      error: (error) =>{
        if(error =="Email exist in database")
        {
          this.existEmail = true;
        }
      }
  });
  }

  get email(){
    return this.loginForm.get('email');
  }

  get firstName(){
    return this.loginForm.get('firstName');
  }
  
  get lastName(){
    return this.loginForm.get('lastName');
  }

  get phoneNumber(){
    return this.loginForm.get('phoneNumber');
  }
  
  get birth(){
    return this.loginForm.get('birth');
  }

  get gender(){
    return this.loginForm.get('gender');
  } 

}
