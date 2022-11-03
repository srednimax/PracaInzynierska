export interface IBookUpdateDto {
    id: number;
    title: string | null;
    author: string | null;
    genre: number;
    publishYear: number;
}