import { IMoviePosterData } from "./IMoviePosterData";

export interface IReviewData {
    reviewId: number;
    name: string;
    postedDate: Date;
    rating: number;
    comment: string;
    moviePosterId: number;
    moviePoster: IMoviePosterData;
}