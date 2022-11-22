import { IGenreDto } from "../Genre/IGenreDto";

export interface IBookAddDto {
    title: string | null;
    author: string | null;
    publishYear: number;
    genres: IGenreDto[];
}