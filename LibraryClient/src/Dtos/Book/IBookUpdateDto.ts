import { IGenreDto } from "../Genre/IGenreDto";

export interface IBookUpdateDto {
    id: number;
    title: string | null;
    author: string | null;
    publishYear: number;
    genres: IGenreDto[];
}