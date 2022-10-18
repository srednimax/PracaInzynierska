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

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UserService } from 'src/services/userService';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/services/JwtInteceptor';
import { RegisterComponent } from './register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SignInUpComponent } from './sign-in-up/sign-in-up.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    FooterComponent,
    SignInUpComponent
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
    TabViewModule
  ],
  providers: [
    UserService,
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
