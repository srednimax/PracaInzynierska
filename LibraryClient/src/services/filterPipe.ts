import { Pipe, PipeTransform } from '@angular/core';
import { IBookDto } from 'src/Dtos/Book/IBookDto';

@Pipe({ name: "filter" })
export class ManualFilterPipe implements PipeTransform {
  transform(bookList: IBookDto[], searchKeyword: string,from:string,to:string) {
    if (!bookList)
      return [];
    if (!searchKeyword && !from && !to)
      return bookList;
    let filteredBookList:IBookDto[] = [];
    if (bookList.length > 0) {
      searchKeyword = searchKeyword.toLowerCase();
      bookList.forEach(book => {
        //Object.values(item) => gives the list of all the property values of the 'item' object
        // let propValueList:any[] = Object.values(book);
        // for(let i=0;i<propValueList.length;i++)
        // {
        //   if (propValueList[i]) {
        //     if (propValueList[i].toString().toLowerCase().indexOf(searchKeyword) > -1)
        //     {
        //         filteredBookList.push(book);
        //       break;
        //     }
        //   }
        // }
        if (searchKeyword && book.title!.toLowerCase().indexOf(searchKeyword) > -1)
            {
                filteredBookList.push(book);
            }
        else if (searchKeyword && book.author!.toLowerCase().indexOf(searchKeyword) > -1){
                filteredBookList.push(book);
            }
        else if(from && to)
        {
            if (book.publishYear! >= Number(from) && book.publishYear <= Number(to) )
            {
                filteredBookList.push(book);
            }
        }
        else if( from && book.publishYear! >= Number(from)){
            filteredBookList.push(book);
        }
        else if(to && book.publishYear! <= Number(to)){
            filteredBookList.push(book);
        }

           
           

           
      });
    }
    return filteredBookList;
  }
}