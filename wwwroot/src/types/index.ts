import * as constants from '../redux/constants';
import { IMovieData, IMoviePosterData, IReviewData } from './api_models';

/*

    Redux - Actions

*/

export interface BaseAction {
    type: string,
    payload?: any
}

export interface GetMoviePostersAction {
    type: constants.REQUEST_GET_MOVIE_POSTERS
}

/*

    Redux - Store Slices

*/

export interface AppState {
    entities: {
        moviePosters: MoviePostersEntityState,
        movies: MoviesEntityState,
        reviews: ReviewsEntityState
    },
    ui: {
        uiGlobals: UiGlobalsState,
        mainMoviePostersList: MainMoviePostersListUiState
    }
}

export interface MoviePostersDict {
    [Key: number]: IMoviePosterData
}

export interface MoviesDict {
    [Key: number]: IMovieData
}

export interface ReviewsDict {
    [Key: number]: IReviewData
}

export interface MoviePostersEntityState {
    byId: MoviePostersDict,
    allIds: number[]
}

export interface MoviesEntityState {
    byId: MoviesDict,
    allIds: number[]
}

export interface ReviewsEntityState {
    byId: ReviewsDict,
    allIds: number[]
}

export interface UiGlobalsState {
    theme: constants.THEME_SETTING,
    srMode: constants.SR_SETTING,
    animationMode: constants.ANIMATION_SETTING,
}

export interface MainMoviePostersListUiState {
    moviePosters: number[],
    state: constants.UI_STATE
}

/*

    Local Component Props

*/
export interface MoviePosterListProps {
    getMoviePostersUrl: string;
}

export interface MoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}