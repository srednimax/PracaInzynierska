import { Component, OnInit } from '@angular/core';
import { IBookDto } from 'src/Dtos/Book/IBookDto';
import { BookService } from 'src/services/bookService';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  constructor(private bookService: BookService) { }

  books: IBookDto[]; 
  page: number =1;

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((resp) => {
      this.books = resp;
    });
  }
  genre(gen:number):string{
    switch(gen){
      case 0:
        return "Fikcja literacka";
        case 1:
        return "Tajemnica";
        case 2:
        return "Kryminał";
        case 3:
        return "Horror";
        case 4:
        return "Historyczna";
        case 5:
        return "Romans";
        case 6:
        return "Western";
        case 7:
        return "Fikcja spekulacyjna";
        case 8:
        return "Science fiction";
        case 9:
        return "Fantazy";
        case 10:
        return;
        case 11:
        return "Literatura realistyczna";
    }
    
    Fikcja literacka,
    Tajemnica,
    Kryminał,
    Przerażenie,
    Historyczny,
    Romans,
    Zachodni,
    Fikcja spekulacyjna,
    Science fiction,
    Fantazja,
    Dystopijczyk,
    Magiczny realizm,
    RealistaLiteratura

  }
}
