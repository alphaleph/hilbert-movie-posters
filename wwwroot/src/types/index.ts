import * as constants from '../redux/constants';
import { IMovieData, IMoviePosterData, IReviewData } from './api_models';
import { MapStateToProps, MapDispatchToProps } from 'react-redux';

/*

    Redux - Actions

*/

export interface BaseAction {
    type: string,
    payload?: any
}

export interface ApiErrorAction {
    type: constants.API_ERROR,
    payload: Error
}
export interface RequestGetMoviePostersAction {
    type: constants.REQUEST_GET_MOVIE_POSTERS
}

export interface DataLoadedMoviePostersAction {
    type: constants.DATA_LOADED_MOVIE_POSTERS,
    payload: IMoviePosterData[]
}

export type MoviePostersApiAction = DataLoadedMoviePostersAction | ApiErrorAction | RequestGetMoviePostersAction | BaseAction;


/* |  | BaseActionRequestGetMoviePostersAction

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

export interface MoviePostersListOwnProps { 
    // imageLoadState: constants.UI_STATE
}
export interface MoviePostersListConnectStateProps {
    moviePostersList: IMoviePosterData[],
    listState: constants.UI_STATE
}
export interface MoviePostersListConnectDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}

export type MoviePostersListProps = MoviePostersListOwnProps & MoviePostersListConnectStateProps & MoviePostersListConnectDispatchProps;
// export type MoviePostersListConnectStateMapper = MapStateToProps<MoviePostersListConnectStateProps, MoviePostersListOwnProps, AppState>;
// export type MoviePostersListDispatchStateMapper = MapDispatchToProps<MoviePostersListConnectDispatchProps, MoviePostersListOwnProps>;


export interface MoviePostersCarouselOwnProps {
    // imageLoadState: constants.UI_STATE;
}

export interface MoviePostersCarouselStateProps {
    moviePostersList: IMoviePosterData[],
    listState: constants.UI_STATE
}

export interface MoviePostersCarouselDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}

export type MoviePostersCarouselProps = MoviePostersCarouselOwnProps & MoviePostersCarouselStateProps & MoviePostersCarouselDispatchProps;


export interface MoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}