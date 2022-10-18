import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SignInUpComponent } from './sign-in-up/sign-in-up.component';



const routes: Routes = [
  {path: 'login',component: LoginComponent},
  {path: 'register',component: RegisterComponent},
  {path: 'signInUp',component: SignInUpComponent},
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
