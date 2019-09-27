import { takeEvery, call, put } from 'redux-saga/effects';
import { REQUEST_GET_MOVIE_POSTERS, API_ERROR, DATA_LOADED_MOVIE_POSTERS } from '../constants';

export function* apiSaga() {
    yield takeEvery( REQUEST_GET_MOVIE_POSTERS, apiSideEffect);
}

function* apiSideEffect() {
    try {
        const data = yield call(getData);
        yield put({ type: DATA_LOADED_MOVIE_POSTERS, payload: data });
    } catch (e) {
        yield put({ type: API_ERROR, payload: e });
    }
}

function getData() {
    return fetch('/api/movieposters')
        .then(response => response.json())
        .catch(error => { error} );
}