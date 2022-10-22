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

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((resp) => {
      this.books = resp;
      console.log(this.books)
    });
  }

}
