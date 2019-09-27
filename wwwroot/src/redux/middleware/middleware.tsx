import { REQUEST_POST_MOVIE_POSTER, INVALID_INPUT } from '../constants';

export const testMiddleware = ({ getState, dispatch }) => {
    return function (next: any) {
        return function (action: any) {
            //Middleware-y things
            console.log('In middleware...');
            if (action.type === REQUEST_POST_MOVIE_POSTER) {
                if (action.payload.name.includes("Hello")) {
                    console.log('Movie poster name includes "Hello..."');
                    return dispatch({ type: INVALID_INPUT });
                }
            }
            return next(action);
        }
    }
}