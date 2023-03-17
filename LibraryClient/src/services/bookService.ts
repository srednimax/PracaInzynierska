import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IBookAddDto } from "src/Dtos/Book/IBookAddDto";
import { IBookDto } from "src/Dtos/Book/IBookDto";
import { IBookUpdateDto } from "src/Dtos/Book/IBookUpdateDto";

@Injectable()
export class BookService {
  url: string = "http://localhost:7196/api/Book";

  constructor(private http: HttpClient) { }
  
  getBooks(): Observable<IBookDto[]> {
    return this.http.get<IBookDto[]>(`${this.url}/GetAll`);
  }

  deleteBook(bookId:number){
    return this.http.delete<IBookDto>(`${this.url}/${bookId}`);
  }

  updateBook(data:IBookUpdateDto){
    return this.http.put<IBookDto>(`${this.url}`,data);
  }
  addBook(data:IBookAddDto){
    return this.http.post<IBookDto>(`${this.url}`,data);
  }
  getRecommendedBooks(){
    return this.http.get<IBookDto[]>(`${this.url}/Recommended`);
  }

}