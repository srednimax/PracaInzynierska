import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IBookRatingAddDto } from "src/Dtos/BookRating/IBookRatingAddDto";
import { IBookRatingDto } from "src/Dtos/BookRating/IBookRatingDto";
import { IBookRatingRemoveDto } from "src/Dtos/BookRating/IBookRatingRemoveDto";
import { IBookRatingUpdateDto } from "src/Dtos/BookRating/IBookRatingUpdateDto";

@Injectable()
export class BookRatingServices {
  url: string = "http://localhost:7196/api/BookRating";

  constructor(private http: HttpClient) { }
  
  getBookRatingsByUser(){
    return this.http.get<IBookRatingDto[]>(`${this.url}/User's`);
  }

  addBookRating(data :IBookRatingAddDto){
    return this.http.post<IBookRatingDto>(`${this.url}`,data);
  }

  updateBookRating(data :IBookRatingUpdateDto){
    return this.http.put<IBookRatingDto>(`${this.url}`,data);
  }

  deleteBookRating(data :IBookRatingRemoveDto){
    return this.http.delete<IBookRatingDto>(`${this.url}`,{body:data});
  }
  getBookRatingByBook(bookId:number){
    return this.http.get<IBookRatingDto[]>(`${this.url}/Book/${bookId}`);
  }

}