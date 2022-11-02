import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { IUserSignInDto } from 'src/Dtos/User/IUserSignInDto';
import { IUserSignUpDto } from 'src/Dtos/User/IUserSignUpDto';

@Injectable()
export class UserService {
  url: string = "https://localhost:7196/api/User";

  constructor(private http: HttpClient) { }

  signInUser(data: IUserSignInDto) {
    return this.http.post<any>(`${this.url}/SignIn`, data, { observe: "response" });
  }
  signUpUser(data:IUserSignUpDto): Observable<IUserDto> {
    return this.http.post<IUserDto>(`${this.url}/SignUp`, data);
  }
  getUser(): Observable<IUserDto> {
    return this.http.get<IUserDto>(this.url);
  }

}