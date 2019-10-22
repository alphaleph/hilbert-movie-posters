import { DATA_LOADED_MOVIE_POSTERS, DATA_LOADED_MOVIE_POSTER } from '../../constants';
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
                        }), {}
                    ),
                    allIds: action.payload.map( (mp: IMoviePosterData) => mp.moviePosterId )
                }
            );
        case DATA_LOADED_MOVIE_POSTER:
            // Check payload to prevent inflight errors from entering state
            if (action.payload.moviePosterId === 0 || action.payload.moviePosterId) {
                return (
                    {
                        byId: { ...state.byId, [action.payload.moviePosterId]: action.payload },
                        allIds: state.allIds.concat([action.payload])
                    }
                );
            }
        // case DELETED_MOVIE_POSTER:
        //     return;
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