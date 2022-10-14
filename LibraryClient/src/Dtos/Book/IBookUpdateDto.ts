export interface IBookUpdateDto {
    id: number;
    title: string | null;
    author: string | null;
    genre: string;
    publishYear: number;
}