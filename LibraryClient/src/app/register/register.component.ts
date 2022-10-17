import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserService } from 'src/services/userService';
import { CustomValidators } from '../customValidators/customValidators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.email]),
    password: new FormControl('',[Validators.required,Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$")]),
    confirmPassword:new FormControl('',[Validators.required]),
    firstName: new FormControl('',[Validators.required]),
    lastName: new FormControl('',[Validators.required]),
    phoneNumber: new FormControl('',[Validators.required]),
    birth: new FormControl('',[Validators.required]),
    gender: new FormControl('',[Validators.required]),
  },
  CustomValidators.mustMatch('password', 'confirmPassword')
  );

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  onSubmit(): void{

  }

  get email(){
    return this.loginForm.get('email');
  }


  get password(){
    return this.loginForm.get('password');
  }

  get confirmPassword(){
    return this.loginForm.get('confirmPassword');
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

  // checkPasswords: Validators = (group: AbstractControl):  ValidationErrors | null => { 
  //   let pass = group.get('password')!.value;
  //   let confirmPass = group.get('confirmPassword')!.value
  //   return pass === confirmPass ? null : { notSame: true }
  // }

  
  

}
