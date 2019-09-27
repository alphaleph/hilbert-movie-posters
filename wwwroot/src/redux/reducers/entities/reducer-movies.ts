import { BaseAction, MoviesEntityState } from '../../../types/index';

const initialState = {
    byId: {},
    allIds: []
};

export const MoviesEntityReducer = (state: MoviesEntityState = initialState, action: BaseAction): MoviesEntityState => {
    switch (action.type) {
        default:
            return state;
    }
}