import React from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePostersListProps } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import { requestGetMoviePosters } from '../redux/actions';
import { MoviePoster } from './movie-poster';
import { ListEmpty } from './list-empty';
import { Error } from './error';
import { Whoops } from './whoops';
import { Loading } from './loading';
import '../styles/components/movie-posters-list';

const mapStateToProps  = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const MoviePostersList: React.FunctionComponent<MoviePostersListProps> = (props: MoviePostersListProps) => {
    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    } 

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error/>
        case UI_LOADED:
            if (props.moviePostersList.length === 0) {
                return <ListEmpty/>;
            }
            return (
                <ul className="moviePostersList--main">
                    {
                    props.moviePostersList.map((mp: IMoviePosterData) => (
                        <li key={mp.moviePosterId}>
                            <MoviePoster 
                                moviePosterName={mp.name} 
                                moviePosterYear={mp.year} 
                            />
                        </li>
                    ))
                    }
                </ul>
            );
        default:
            return <Whoops/>
    }
}

export const ConnectedMoviePostersList = connect(mapStateToProps, mapDispatchToProps)(MoviePostersList as unknown as any);
