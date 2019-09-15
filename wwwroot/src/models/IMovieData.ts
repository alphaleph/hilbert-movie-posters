import { IMoviePosterData } from "./IMoviePosterData";

export interface IMovieData {
    id: number;
    name: string;
    year: number;
    moviePosters: IMoviePosterData[];
}