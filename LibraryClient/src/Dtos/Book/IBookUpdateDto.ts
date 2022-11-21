import { IGenreDto } from "../Genre/IGenreDto";

export interface BookUpdateDto {
    id: number;
    title: string | null;
    author: string | null;
    publishYear: number;
    genres: IGenreDto[];
}