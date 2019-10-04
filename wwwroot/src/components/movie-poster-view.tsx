import React from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePosterViewProps } from '../types/index';
import { requestGetMoviePosters } from '../redux/actions';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import StarRatingComponent from 'react-star-rating-component';
import '../styles/components/movie-poster-view.scss';
import { Loading } from './loading';
import { Error } from './error';

const mapStateToProps = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const MoviePosterView: React.FunctionComponent<MoviePosterViewProps> = (props: MoviePosterViewProps) => {
    
    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    }

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error/>;
        case UI_LOADED:
            //TODO: Check for individual movie poster in state based on moviePosterId in URL, if not present, then download    

            return (
                <Container className="movie-poster-view--container my-2">
                    <h1>THIS IS THE MOVIE POSTER TITLE by UNKNOWN</h1>
                    <Col className="movie-poster-view--left-col">
                        <h2>Movie Poster Image and Info...</h2>
                        <StarRatingComponent name="Sample rating" value={3}/>
                    </Col>
                    <Col className="movie-poster-view--right-col">
                        <h2>
                            Reviews list...
                        </h2>
                    </Col>
                </Container>
            );
        default:
            return <Loading/>;
    }
}

export const ConnectedMoviePosterView = connect(mapStateToProps, mapDispatchToProps)(MoviePosterView);