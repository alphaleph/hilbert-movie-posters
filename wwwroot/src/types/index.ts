import * as constants from '../redux/constants';
import { IMovieData, IMoviePosterData, IReviewData, IApiError } from './api_models';
import { MapStateToProps, MapDispatchToProps } from 'react-redux';
import { RouteComponentProps } from 'react-router';

/*

    Redux - Actions

*/

export interface BaseAction {
    type: string,
    payload?: any
}

export interface ApiErrorAction {
    type: constants.API_ERROR,
    payload: IApiError
}

export interface ApiRecoverAction {
    type: constants.API_RECOVER
}

export interface RequestGetMoviePostersAction {
    type: constants.REQUEST_GET_MOVIE_POSTERS
}

export interface DataLoadedMoviePostersAction {
    type: constants.DATA_LOADED_MOVIE_POSTERS,
    payload: IMoviePosterData[]
}

export type MoviePostersApiAction = ApiErrorAction | DataLoadedMoviePostersAction | 
                                        ApiRecoverAction | RequestGetMoviePostersAction | BaseAction;


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
    state: constants.UI_STATE,
    error: IApiError
}

/*

    Local Component Props

*/
export interface IAccessMoviePostersList {
    moviePostersList: IMoviePosterData[],
    listState: constants.UI_STATE
}

export interface MoviePostersListOwnProps { 
    // imageLoadState: constants.UI_STATE
}
export interface MoviePostersListConnectStateProps extends IAccessMoviePostersList {}
export interface MoviePostersListConnectDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}
export type MoviePostersListProps = MoviePostersListOwnProps & MoviePostersListConnectStateProps & MoviePostersListConnectDispatchProps;
// export type MoviePostersListConnectStateMapper = MapStateToProps<MoviePostersListConnectStateProps, MoviePostersListOwnProps, AppState>;
// export type MoviePostersListDispatchStateMapper = MapDispatchToProps<MoviePostersListConnectDispatchProps, MoviePostersListOwnProps>;


export interface MoviePostersCarouselOwnProps {
    // imageLoadState: constants.UI_STATE;
    // carouselBufferSize: number;
}
export interface MoviePostersCarouselStateProps extends IAccessMoviePostersList {}
export interface MoviePostersCarouselDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}
export type MoviePostersCarouselProps = MoviePostersCarouselOwnProps & MoviePostersCarouselStateProps & MoviePostersCarouselDispatchProps;


export interface MoviePostersCardColumnsOwnProps { 
    //cardColumnsBufferSize: number;
}
export interface MoviePostersCardColumnsStateProps extends IAccessMoviePostersList {}
export interface MoviePostersCardColumnsDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}
export type MoviePostersCardColumnsProps = MoviePostersCardColumnsOwnProps & MoviePostersCardColumnsStateProps & MoviePostersCardColumnsDispatchProps;


type TParams = { id: string };
export interface MoviePosterViewOwnProps extends RouteComponentProps<TParams> {};
export interface MoviePosterViewStateProps extends IAccessMoviePostersList {
    availableMoviePosters: number[]
}
export interface MoviePosterViewDispatchProps {
    requestGetMoviePosters: () => RequestGetMoviePostersAction
}
export type MoviePosterViewProps = MoviePosterViewOwnProps & MoviePosterViewStateProps & MoviePosterViewDispatchProps;

export interface MoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}

export interface UnderConstructionProps {
    pageName: string;
}

export interface ErrorProps {
    error: IApiError
    history: history.History
    apiRecover: () => ApiRecoverAction
}