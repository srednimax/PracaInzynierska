export interface IBookDto {
    id: number;
    title: string | null;
    author: string | null;
    genre: number;
    publishYear: number;
    isBorrowed: boolean;
    rating:number;
}

export interface IGenre{
    number:number;
    name:string;
}