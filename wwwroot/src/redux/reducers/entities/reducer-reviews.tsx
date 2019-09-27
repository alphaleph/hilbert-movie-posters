import { BaseAction, ReviewsEntityState } from '../../../types/index';

const initialState = {
    byId: {},
    allIds: []
}

export const ReviewsEntityReducer = (state: ReviewsEntityState = initialState, action: BaseAction): ReviewsEntityState => {
    switch (action.type) {
        default:
            return state;
    }
}