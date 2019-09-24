import { IMovieData, IMoviePosterData, IReviewData } from './models';

export interface MoviePosterListProps {
    getMoviePostersUrl: string;
}

export interface MoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}