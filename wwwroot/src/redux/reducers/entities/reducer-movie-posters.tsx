import { REQUEST_GET_MOVIE_POSTER, DATA_LOADED_MOVIE_POSTERS } from '../../constants';
import { BaseAction, MoviePostersEntityState, MoviePostersDict } from '../../../types/index';
import { IMoviePosterData } from '../../../types/api_models';

const initialState = {
    byId: {},
    allIds: []
}

export const MoviePostersEntityReducer = (state: MoviePostersEntityState = initialState, action: BaseAction): MoviePostersEntityState => {
    switch (action.type) {
        case DATA_LOADED_MOVIE_POSTERS:
            return (
                {
                    byId: action.payload.reduce( (acc: MoviePostersDict, moviePoster: IMoviePosterData) => (
                        {
                            ...acc, 
                            [moviePoster.moviePosterId]: moviePoster
                        }), 
                        state
                    ),
                    allIds: action.payload.map( (mp: IMoviePosterData) => mp.moviePosterId )
                }
            );
        // case ADD_MOVIE_POSTER:
        //     const { id, content } = action.payload;
        //     return ({
        //         ...state,
        //         byId: {
        //             ...state.byId,
        //             [id]: {
        //                 content,
        //                 completed: false
        //             }
        //         },
        //         allIds: [...state.allIds, id],
        //     });
        default:
            return state;
    }
}