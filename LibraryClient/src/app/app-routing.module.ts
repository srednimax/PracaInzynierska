import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SignInUpComponent } from './sign-in-up/sign-in-up.component';
import { HomeComponent } from './home/home.component';



const routes: Routes = [
  {path: 'signInUp',component: SignInUpComponent},
  {path: '',component: HomeComponent},
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
