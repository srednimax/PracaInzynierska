import { IGenreDto } from "../Genre/IGenreDto";

export interface IBookDto {
    id: number;
    title: string | null;
    author: string | null;
    genres: IGenreDto[];
    publishYear: number;
    isBorrowed: boolean;
    rating: number;
}