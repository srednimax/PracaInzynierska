import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IGenreAddDto } from "src/Dtos/Genre/IBookAddDto";
import { IGenreUpdateDto } from "src/Dtos/Genre/IBookUpdateDto";
import { IGenreDto } from "src/Dtos/Genre/IGenreDto";

@Injectable()
export class GenreService {
  url: string = "https://localhost:7196/api/Genre";

  constructor(private http: HttpClient) { }
  
  getAll() {
    return this.http.get<IGenreDto[]>(`${this.url}/All`);
  }

  AddGenre( data: IGenreAddDto) {
    return this.http.post<IGenreDto>(this.url,data);
  }

  updateGenre(data:IGenreUpdateDto) {
    return this.http.put<IGenreDto>(this.url,data);
  }

  deleteGenre(id:number) {
    return this.http.delete<IGenreDto>(`${this.url}/${id}`);
  }

 
}