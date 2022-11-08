import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserDto } from 'src/Dtos/User/IUserDto';
import { IUserSignInDto } from 'src/Dtos/User/IUserSignInDto';
import { IUserSignUpDto } from 'src/Dtos/User/IUserSignUpDto';
import { IUserUpdateDto } from 'src/Dtos/User/IUserUpdateDto';
import { IUserUpdatePasswordDto } from 'src/Dtos/User/IUserUpdatePasswordDto';

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
  updateUser(data :IUserUpdateDto){
    return this.http.put<IUserDto>(this.url,data);
  }

  updatePassword(data :IUserUpdatePasswordDto){
    return this.http.put<IUserDto>(`${this.url}/ChangePassword`,data);
  }
  payPenalty(){
    return this.http.put<IUserDto>(`${this.url}/Penalty`,null);
  }

}