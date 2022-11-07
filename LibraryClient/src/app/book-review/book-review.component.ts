import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBookRatingDto } from 'src/Dtos/BookRating/IBookRatingDto';
import { BookRatingServices } from 'src/services/bookRatingServices';

@Component({
  selector: 'app-book-review',
  templateUrl: './book-review.component.html',
  styleUrls: ['./book-review.component.css']
})
export class BookReviewComponent implements OnInit {

  constructor(private bookRatingService:BookRatingServices,private route: ActivatedRoute) { }

  ratings:IBookRatingDto[];
  bookId:number;


  ngOnInit(): void {
    this.bookRatingService.getBookRatingByBook(Number(this.route.snapshot.paramMap.get('id'))).subscribe(resp=>{
      this.ratings = resp;
    })

  }

}
