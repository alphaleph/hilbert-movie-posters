import { RequestGetMoviePostersAction, DataLoadedMoviePostersAction, ApiErrorAction } from '../types/index';
import { REQUEST_POST_MOVIE_POSTER, REQUEST_GET_MOVIE_POSTERS, DATA_LOADED_MOVIE_POSTERS, API_ERROR } from './constants';
import { IMoviePosterData } from '../types/api_models';

export const requestGetMoviePosters = (): RequestGetMoviePostersAction => {
    return { 
        type: REQUEST_GET_MOVIE_POSTERS,
    };
}

export const dataLoadedMoviePosters = (data: IMoviePosterData[]): DataLoadedMoviePostersAction => {
    return {
        type: DATA_LOADED_MOVIE_POSTERS, 
        payload: data
    }
}

export const apiError = (e: Error): ApiErrorAction => {
    return {
        type: API_ERROR,
        payload: e
    }
}

// let nextMoviePosterId = 0;
// export const addMoviePoster = (payload) => {
//     type: REQUEST_POST_MOVIE_POSTER,
//     payload: payload
// }