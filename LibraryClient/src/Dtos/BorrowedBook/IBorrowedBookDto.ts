import { IBookDto } from "../Book/IBookDto";
import { IUserDto } from "../User/IUserDto";

export interface IBorrowedBookDto {
    id: number;
    book: IBookDto | null;
    employee: IUserDto | null;
    reader: IUserDto | null;
    status: number;
    borrowDate: string | null;
    returnDate: string | null;
    returnedDate: string | null;
    isRenew: boolean;
    isReturned: boolean;
    isRated: boolean;
}

export interface IStatus{
    number:number;
    name:string;
}