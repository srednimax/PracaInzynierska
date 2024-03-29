import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//primeng
import {InputTextModule} from 'primeng/inputtext';
import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';
import {CalendarModule} from 'primeng/calendar';
import {PasswordModule} from 'primeng/password';
import {DropdownModule} from 'primeng/dropdown';
import {TabViewModule} from 'primeng/tabview';
import {TableModule} from 'primeng/table';
import {PaginatorModule} from 'primeng/paginator';
import {ToastModule} from 'primeng/toast';
import {CheckboxModule} from 'primeng/checkbox';
import {MultiSelectModule} from 'primeng/multiselect';
import {RatingModule} from 'primeng/rating';
import {DialogModule} from 'primeng/dialog';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {InputNumberModule} from 'primeng/inputnumber';
import {ConfirmDialog, ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService} from 'primeng/api';

//pagination
import {NgxPaginationModule} from 'ngx-pagination'; 

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UserService } from 'src/services/userService';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/services/JwtInteceptor';
import { RegisterComponent } from './register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SignInUpComponent } from './sign-in-up/sign-in-up.component';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { BookService } from 'src/services/bookService';
import { BorrowingBookService } from 'src/services/borrowingBookServices';
import { MessageService } from 'primeng/api';
import { ManualFilterPipe } from 'src/services/filterPipe';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { BookRatingServices } from 'src/services/bookRatingServices';
import { UserProfileUpdateComponent } from './user-profile-update/user-profile-update.component';
import { UserProfileBorrowedBooksComponent } from './user-profile-borrowed-books/user-profile-borrowed-books.component';
import { EmployeeComponent } from './employee/employee.component';
import { ExtraFunctions } from 'src/services/extraFunctions';
import { EmployeeBooksComponent } from './employee-books/employee-books.component';
import { EmployeeBorrowedBooksComponent } from './employee-borrowed-books/employee-borrowed-books.component';
import { BookReviewComponent } from './book-review/book-review.component';
import { UserProfileRecomendationComponent } from './user-profile-recomendation/user-profile-recomendation.component';
import { UserProfilePenaltyComponent } from './user-profile-penalty/user-profile-penalty.component';
import { GenreService } from 'src/services/genreService';
import { EmployeeGenreComponent } from './employee-genre/employee-genre.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    FooterComponent,
    SignInUpComponent,
    HomeComponent,
    BooksComponent,
    ManualFilterPipe,
    UserProfileComponent,
    UserProfileUpdateComponent,
    UserProfileBorrowedBooksComponent,
    EmployeeComponent,
    EmployeeBooksComponent,
    EmployeeBorrowedBooksComponent,
    BookReviewComponent,
    UserProfileRecomendationComponent,
    UserProfilePenaltyComponent,
    EmployeeGenreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    InputTextModule,
    CardModule,
    ButtonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    CalendarModule,
    BrowserAnimationsModule,
    PasswordModule,
    DropdownModule,
    TabViewModule,
    TableModule,
    PaginatorModule,
    NgxPaginationModule,
    ToastModule,
    CheckboxModule,
    MultiSelectModule,
    RatingModule,
    DialogModule,
    InputTextareaModule,
    InputNumberModule, 
    ConfirmDialogModule,
    
  ],
  providers: [
    UserService,
    BookService,
    BorrowingBookService,
    BookRatingServices,
    MessageService,
    ConfirmationService,
    ExtraFunctions,
    GenreService,
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
