import { IMovieData } from './IMovieData';
import { IPosterImageData } from './IPosterImageData';
import { IReviewData } from './IReviewData';

export interface IMoviePosterData {
    id: number;
    posterImage: IPosterImageData;
    name: string;
    year: number;
    artist: string;
    rating: number;
    ratingCount: number;
    movie: IMovieData;
    reviews: IReviewData[];
}
