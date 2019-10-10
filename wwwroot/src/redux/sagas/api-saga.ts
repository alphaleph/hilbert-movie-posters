import { takeEvery, call, put } from 'redux-saga/effects';
import * as constants from '../constants';
import * as types from '../../types/index';
import * as actions from '../actions';
import { IMoviePosterData, IApiError } from '../../types/api_models';

export function* apiSaga() {
    yield takeEvery(constants.REQUEST_GET_MOVIE_POSTERS, getMoviePosters);
    yield takeEvery(constants.REQUEST_GET_MOVIE_POSTER, getMoviePoster);
}

function* getMoviePosters() {
    try {
        const data = yield call(fetchMoviePosters);
        yield put(actions.dataLoadedMoviePosters(data));
    } catch (e) {
        console.log(e);
        yield put(actions.apiError(e));
    }
}

function fetchMoviePosters() {
    return fetch('/api/movieposters')
        .then(response => response.json())
        .catch(error =>  error );
}

function* getMoviePoster(action: types.RequestGetMoviePosterAction) {
    try {
        const data: IMoviePosterData = yield call(fetchMoviePoster, action.payload);
        if (data.moviePosterId === 0 || data.moviePosterId) {
            yield put(actions.dataLoadedMoviePoster(data));
        } else {
            console.log(data + " In try");
            yield put(actions.apiError(data as unknown as IApiError));
        }
    } catch (e) {
        console.log(e + " In Catch");
        yield put(actions.apiError(e));
    }
}

function fetchMoviePoster(id: number) {
    return fetch(`/api/movieposters/${id}`)
        .then(response => response.json())
        .catch(error =>  error )
}