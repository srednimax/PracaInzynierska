export interface IBookRatingUpdateDto {
    id: number;
    bookId: number;
    comment: string | null;
    rating: number;
}