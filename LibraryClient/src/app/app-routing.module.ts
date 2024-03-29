import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInUpComponent } from './sign-in-up/sign-in-up.component';
import { HomeComponent } from './home/home.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { BookReviewComponent } from './book-review/book-review.component';



const routes: Routes = [
  {path: 'signInUp',component: SignInUpComponent},
  {path: '',component: HomeComponent},
  {path: 'profile',component: UserProfileComponent},
  {path: 'book/:id',component: BookReviewComponent},
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
