export interface IMovieData {
    movieId: number;
    name: string;
    year: number;
    moviePosters: IMoviePosterData[];
}

export interface IMoviePosterData {
    moviePosterId: number;
    posterImageUrl: string;
    name: string;
    year: number;
    artist: string;
    rating: number;
    ratingCount: number;
    movieId: number;
    movie: IMovieData;
    reviews: IReviewData[];
}

export interface IReviewData {
    reviewId: number;
    name: string;
    postedDate: Date;
    rating: number;
    comment: string;
    moviePosterId: number;
    moviePoster: IMoviePosterData;
}

export interface IMoviePosterForm {
    name: string,
    year: number,
    artist: string,
    posterImageUrl: string,
    movieId?: number
}

export interface IMovieForm {
    name: string,
    year: number
}

export interface IReviewForm {
    name: string,
    rating: number,
    comment?: string
}