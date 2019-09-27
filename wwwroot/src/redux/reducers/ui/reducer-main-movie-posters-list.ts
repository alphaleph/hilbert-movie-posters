import { BaseAction, MainMoviePostersListUiState, MoviePostersEntityState } from '../../../types/index';
import { UI_INIT, REQUEST_GET_MOVIE_POSTERS, UI_LOADING, DATA_LOADED_MOVIE_POSTERS, UI_LOADED } from '../../constants';

const initialState = {
    moviePosters: [],
    state: UI_INIT as UI_INIT
}

export const MainMoviePostersListReducer = (state: MainMoviePostersListUiState = initialState, 
                                            action: BaseAction, 
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
            return {
                ...state,
                state: UI_LOADED,
                moviePosters: moviePostersEntity.allIds
            };
        default:
            return state;
    }
}