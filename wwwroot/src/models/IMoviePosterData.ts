import { IMovieData } from './IMovieData';
import { IPosterImageData } from './IPosterImageData';
import { IReviewData } from './IReviewData';

export interface IMoviePosterData {
    moviePosterId: number;
    posterImage: IPosterImageData;
    name: string;
    year: number;
    artist: string;
    rating: number;
    ratingCount: number;
    movieId: number;
    movie: IMovieData;
    reviews: IReviewData[];
}
