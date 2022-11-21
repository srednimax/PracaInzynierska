import { IGenreDto } from "../Genre/IGenreDto";

export interface BookAddDto {
    title: string | null;
    author: string | null;
    publishYear: number;
    genres: IGenreDto[];
}