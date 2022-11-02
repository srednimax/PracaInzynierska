import { IBookDto } from "../Book/IBookDto";
import { IUserDto } from "../User/IUserDto";

export interface IBookRatingDto {
    id: number;
    book: IBookDto | null;
    user: IUserDto | null;
    comment: string | null;
    rating: number;
}