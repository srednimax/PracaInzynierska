import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IBookDto } from "src/Dtos/Book/IBookDto";

@Injectable()
export class BorrowingBookService {
  url: string = "https://localhost:7196/api/BorrowingBook";

  constructor(private http: HttpClient) { }
  
  borrowBooks(bookId:number) {
    return this.http.post(`${this.url}/${bookId}`,null);
  }

}