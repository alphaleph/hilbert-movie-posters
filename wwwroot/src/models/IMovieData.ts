import { IMoviePosterData } from "./IMoviePosterData";

export interface IMovieData {
    movieId: number;
    name: string;
    year: number;
    moviePosters: IMoviePosterData[];
}