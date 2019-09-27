import { createStore, applyMiddleware, compose } from 'redux';
import { RootReducer } from './reducers/index';
import { testMiddleware } from './middleware/middleware';
import createSagaMiddleware from 'redux-saga';
import { apiSaga } from '../sagas/api-saga';

const sagaMiddleware = createSagaMiddleware();

const storeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const Store = createStore(
    RootReducer, 
    storeEnhancers(
        applyMiddleware(testMiddleware, sagaMiddleware)
    )
);

sagaMiddleware.run(apiSaga);