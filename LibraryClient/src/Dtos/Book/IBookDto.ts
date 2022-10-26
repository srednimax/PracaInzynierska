export interface IBookDto {
    id: number;
    title: string | null;
    author: string | null;
    genre: number;
    publishYear: number;
    isBorrowed: boolean;
}