import { GetMoviePostersAction } from '../types/index';
import { REQUEST_POST_MOVIE_POSTER, REQUEST_GET_MOVIE_POSTERS } from './constants';

export const getMoviePosters = (): GetMoviePostersAction => {
    return { 
        type: REQUEST_GET_MOVIE_POSTERS,
    };
}

// let nextMoviePosterId = 0;
// export const addMoviePoster = (payload) => {
//     type: REQUEST_POST_MOVIE_POSTER,
//     payload: payload
// }