import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserSignInDto } from 'src/Dtos/User/IUserSignInDto';

@Injectable()
export class UserService {
  url: string = "https://localhost:7196/api/User";

  constructor(private http: HttpClient) { }

  signInUser(data: IUserSignInDto) {
    return this.http.post<any>(`${this.url}/SignIn`, data, { observe: "response" });
  }
  // getUser(): Observable<IUserDto> {
  //   return this.http.get<IUserDto>(this.url);
  // }

}