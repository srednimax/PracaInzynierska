export interface IBookDto {
    id: number;
    title: string | null;
    author: string | null;
    genre: string;
    publishYear: number;
    isBorrowed: boolean;
}