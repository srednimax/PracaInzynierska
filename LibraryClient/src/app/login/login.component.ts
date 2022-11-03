import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { IUserSignInDto } from 'src/Dtos/User/IUserSignInDto';
import { UserService } from 'src/services/userService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  wrongCredentials:boolean;

  loginForm = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.email]),
    password: new FormControl('',[Validators.required])
  });
  constructor(private userService: UserService,private router:Router) { }


  ngOnInit(): void {
  }

  onSubmit(): void {
    this.wrongCredentials = false;

    let userSignIn : IUserSignInDto ={
      email: this.loginForm.controls.email.value,
      password: this.loginForm.controls.password.value
    };
    this.userService.signInUser(userSignIn).subscribe(
      {next: (resp) =>{
        localStorage.setItem("token", resp.headers.get("jwt")!);
        localStorage.setItem("user",JSON.stringify(resp.body))
        this.router.navigate(["/"]).then(()=>{
          window.location.reload();
        });
      },
      error: (error) =>{
        if(error =="Wrong email or password")
        {
          this.wrongCredentials = true;
        }
      }
  });
  }

  get email(){
    return this.loginForm.get('email');
  }
  
  get password(){
    return this.loginForm.get('password');
  }

}
