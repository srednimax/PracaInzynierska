export interface IBookDto {
    id: number;
    title: string;
    author: string;
    genre: number;
    publishYear: number;
    isBorrowed: boolean;
    rating:number;
}

export interface IGenre{
    number:number;
    name:string;
}