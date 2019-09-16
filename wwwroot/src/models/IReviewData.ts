import { IMoviePosterData } from "./IMoviePosterData";

export interface IReviewData {
    id: number;
    name: string;
    postedDate: Date;
    rating: number;
    comment: string;
    moviePoster: IMoviePosterData;
}