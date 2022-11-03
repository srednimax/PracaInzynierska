import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IBookDto } from "src/Dtos/Book/IBookDto";

@Injectable()
export class BookService {
  url: string = "https://localhost:7196/api/Book";

  constructor(private http: HttpClient) { }
  
  getBooks(): Observable<IBookDto[]> {
    return this.http.get<IBookDto[]>(`${this.url}/GetAll`);
  }
  deleteBook(bookId:number){
    return this.http.delete<IBookDto>(`${this.url}/${bookId}`);
  }

}