import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IBookRatingDto } from "src/Dtos/BookRating/IBookRatingDto";

@Injectable()
export class BookRatingServices {
  url: string = "https://localhost:7196/api/BookRating";

  constructor(private http: HttpClient) { }
  
  getBookRatingsByUser(){
    return this.http.get<IBookRatingDto[]>(`${this.url}/User's`);
  }

}