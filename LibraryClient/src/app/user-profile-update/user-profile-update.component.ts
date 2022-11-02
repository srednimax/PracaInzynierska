import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { IGender, IUserSignUpDto } from 'src/Dtos/User/IUserSignUpDto';
import { IUserUpdateDto } from 'src/Dtos/User/IUserUpdateDto';
import { UserService } from 'src/services/userService';
import { CustomValidators } from '../customValidators/customValidators';

@Component({
  selector: 'app-user-profile-update',
  templateUrl: './user-profile-update.component.html',
  styleUrls: ['./user-profile-update.component.css']
})
export class UserProfileUpdateComponent implements OnInit {


  user:IUserDto;

  updateForm = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.email]),
    firstName: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z]{3,50}$")]),
    lastName: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z]{3,50}$")]),
    phoneNumber: new FormControl('',[Validators.required,Validators.required,Validators.pattern("^[1-9][0-9]{8,8}$")]),
    gender: new FormControl('',[Validators.required]),
  });

  passwordForm = new FormGroup(
    {
      oldPassword: new FormControl('',[Validators.required]),
      newPassword: new FormControl('',[Validators.required,Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$")]),
      confirmNewPassword: new FormControl('',[Validators.required])
    },
  CustomValidators.mustMatch('newPassword', 'confirmNewPassword')
  )

  existEmail:boolean;
  genders : IGender[] = [{number:0,name:'wole nie podawać'},{number:1,name:'mężczyzna'},{number:2,name:'kobieta'}];

  constructor(private userService:UserService) { }

  ngOnInit( ): void {
    this.userService.getUser().subscribe(resp =>{
      this.user=resp;
      this.updateF();
    })
    
  }

  onSubmit(): void{
    this.existEmail = false;

    let userUpdateDto : IUserUpdateDto ={
      id:0,
      email: this.updateForm.controls.email.value,
      firstName: this.updateForm.controls.firstName.value,
      lastName: this.updateForm.controls.lastName.value,
      phoneNumber: this.updateForm.controls.phoneNumber.value,
      gender: this.updateForm.controls.gender.value
    };
    this.userService.updateUser(userUpdateDto).subscribe(
      {next: (resp) =>{
        this.user=resp;
        this.updateF();
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
    return this.updateForm.get('email');
  }

  get firstName(){
    return this.updateForm.get('firstName');
  }
  
  get lastName(){
    return this.updateForm.get('lastName');
  }

  get phoneNumber(){
    return this.updateForm.get('phoneNumber');
  }

  get gender(){
    return this.updateForm.get('gender');
  } 

  //password form
  get oldPassword(){
    return this.passwordForm.get('oldPassword');
  } 
  get newPassword(){
    return this.passwordForm.get('newPassword');
  } 
  get confirmNewPassword(){
    return this.passwordForm.get('confirmNewPassword');
  } 


  updateF():void{
    this.email?.setValue(this.user.email);
    this.firstName?.setValue(this.user.firstName);
    this.lastName?.setValue(this.user.lastName);
    this.phoneNumber?.setValue(this.user.phoneNumber);
    this.gender?.setValue(this.user.gender);
  }

  onSubmitPassword():void{

  }

}
