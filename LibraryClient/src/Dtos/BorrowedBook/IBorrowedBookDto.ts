import { IBookDto } from "../Book/IBookDto";
import { IUserDto } from "../User/IUserDto";

export interface IBorrowedBookDto {
    id: number;
    book: IBookDto | null;
    employee: IUserDto | null;
    reader: IUserDto | null;
    status: string;
    borrowDate: string | null;
    returnDate: string | null;
    isRenew: boolean;
    isReturned: boolean;
}