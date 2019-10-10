import { MoviePostersApiAction, MainMoviePostersListUiState, MoviePostersEntityState, 
    MoviePostersDict, DataLoadedMoviePostersAction, ApiErrorAction } from '../../../types/index';
import { UI_INIT, REQUEST_GET_MOVIE_POSTERS, UI_LOADING, DATA_LOADED_MOVIE_POSTERS, 
    UI_LOADED, UI_ERROR, API_ERROR, API_RECOVER } from '../../constants';

const initialState = {
    moviePosters: [],
    state: UI_INIT as UI_INIT,
    error: { code: 42, message: '' }
}

export const MainMoviePostersListReducer = (state: MainMoviePostersListUiState = initialState, 
                                            action: MoviePostersApiAction, 
                                            moviePostersEntity: MoviePostersEntityState
                                            ) : MainMoviePostersListUiState => {
    switch (action.type) {
        case REQUEST_GET_MOVIE_POSTERS:
            return {
                ...state,
                state: UI_LOADING,
                moviePosters: []
            };
        case DATA_LOADED_MOVIE_POSTERS:
            moviePostersEntity = {
                // TODO: Address TS dict syntax vs type inference
                byId: (<DataLoadedMoviePostersAction>action).payload.reduce((acc, mp) => ({ ...acc, [mp.moviePosterId]: mp})) as unknown as MoviePostersDict,
                allIds:(<DataLoadedMoviePostersAction>action).payload.map(mp => mp.moviePosterId)
            };
            return {
                ...state,
                state: UI_LOADED,
                moviePosters: moviePostersEntity.allIds
            };
        case API_ERROR:
            return {
                ...state,
                state: UI_ERROR,
                error: (<ApiErrorAction>action).payload
            }
        case API_RECOVER:
            return {
                ...state,
                state: UI_INIT,
                moviePosters: [],
                error: { code: 42, message: '' }
            }
        default:
            return state;
    }
}