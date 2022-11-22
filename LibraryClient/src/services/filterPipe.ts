import { Pipe, PipeTransform } from "@angular/core";
import { IBookDto } from "src/Dtos/Book/IBookDto";
import { IGenreDto } from "src/Dtos/Genre/IGenreDto";

@Pipe({ name: "filter" })
export class ManualFilterPipe implements PipeTransform {
  transform(
    bookList: IBookDto[],
    search: string,
    from: string,
    to: string,
    isAvalible: boolean,
    selectedGenres: IGenreDto[]
  ) {
    if (!bookList) return [];

    if (isAvalible) {
      bookList = bookList.filter((x) => x.isBorrowed === false);
    }
    if (selectedGenres.length > 0) {
      bookList = bookList.filter((book) => {
        const arr1 = selectedGenres.map((x) => x.id);
        const arr2 = book.genres.map((x) => x.id);
        const containsAll = arr1.every((element) => {
          return arr2.indexOf(element) !== -1;
        });
        return containsAll;
      });
    }
    if (!search && !from && !to) return bookList;
    if (bookList.length > 0) {
      search = search.toLowerCase();

      bookList = bookList.filter(
        (book) =>
          (search && book.title!.toLowerCase().indexOf(search) > -1) ||
          (search && book.author!.toLowerCase().indexOf(search) > -1)
      );

      if (from && to) {
        bookList = bookList.filter(
          (book) =>
            book.publishYear! >= Number(from) && book.publishYear <= Number(to)
        );
        return bookList;
      }

      if (from) {
        bookList = bookList.filter((book) => book.publishYear! >= Number(from));
      }
      if (to) {
        bookList = bookList.filter((book) => book.publishYear! <= Number(to));
      }
    }

    return bookList;
  }
}
