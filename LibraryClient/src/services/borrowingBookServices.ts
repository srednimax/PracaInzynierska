import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IBorrowedBookChangeStatusDto } from "src/Dtos/BorrowedBook/IBorrowedBookChangeStatus";
import { IBorrowedBookDto } from "src/Dtos/BorrowedBook/IBorrowedBookDto";
import { IBorrowedBookReturnDto } from "src/Dtos/BorrowedBook/IBorrowedBookReturnDto";

@Injectable()
export class BorrowingBookService {
  url: string = "http://localhost:7196/api/BorrowingBook";

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

  changeStatus(data:IBorrowedBookChangeStatusDto){
    return this.http.put<IBorrowedBookDto>(`${this.url}/ChangeStatus`,data);
  }
  
  returnBook(data:IBorrowedBookReturnDto){
    return this.http.put<IBorrowedBookDto>(`${this.url}/Return`,data);
  }
 
}