import { IMoviePosterData } from "./IMoviePosterData";

export interface IReview {
    id: number;
    name: string;
    postedDate: Date;
    rating: number;
    comment: string;
    moviePoster: IMoviePosterData;
}