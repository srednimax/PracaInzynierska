import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IBorrowedBookDto } from "src/Dtos/BorrowedBook/IBorrowedBookDto";

@Injectable()
export class BorrowingBookService {
  url: string = "https://localhost:7196/api/BorrowingBook";

  constructor(private http: HttpClient) { }
  
  borrowBooks(bookId:number) {
    return this.http.post(`${this.url}/${bookId}`,null);
  }

  getBorrowedBooksByUser() {
    return this.http.get<IBorrowedBookDto[]>(`${this.url}/UserBook's`);
  }

  renewBook(borrowedBookId:number){
    return this.http.put(`${this.url}/Renew/${borrowedBookId}`,null);
  }

  cancelBook(borrowedBookId:number){
    return this.http.put<IBorrowedBookDto>(`${this.url}/Cancel/${borrowedBookId}`,null);
  }

  getBorrowedBooks(){
    return this.http.get<IBorrowedBookDto[]>(this.url);
  }
 
}