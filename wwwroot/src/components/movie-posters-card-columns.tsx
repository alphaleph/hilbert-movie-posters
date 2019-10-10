import React from 'react';
import { connect } from 'react-redux';
import { MoviePostersCardColumnsProps, AppState } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { selectMoviePosters } from '../redux/selectors';
import { requestGetMoviePosters } from '../redux/actions';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import Card from 'react-bootstrap/Card';
import CardColumns from 'react-bootstrap/CardColumns'
import StarRatingComponent from 'react-star-rating-component';
import { LinkContainer } from 'react-router-bootstrap';
import { Loading } from './loading';
import { Error } from './error';
import { ListEmpty } from './list-empty';

import '../styles/components/movie-posters-card-columns';

const CARD_COLUMNS_BUFFER_SIZE = 30;

const mapStateToProps = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const DisconnectedMoviePostersCardColumns: React.FunctionComponent<MoviePostersCardColumnsProps> = (props: MoviePostersCardColumnsProps) => {

    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    }

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
                return <Error history={props.history}/>;
        case UI_LOADED:
            if (props.moviePostersList.length === 0) {
                return <ListEmpty/>;
            }
            const moviePostersBuffer = (props.moviePostersList.length > CARD_COLUMNS_BUFFER_SIZE) 
                                        ? props.moviePostersList.slice(0, CARD_COLUMNS_BUFFER_SIZE)
                                        : props.moviePostersList;
            const cards = moviePostersBuffer.map((mp: IMoviePosterData) =>
                    <Card key={mp.moviePosterId} border="dark">
                        <Card.Img variant="top" src={mp.posterImageUrl}/>
                        <Card.Body>
                            <LinkContainer className="link" tabIndex={0} to={`/view/movie-posters/${mp.moviePosterId}`}>
                                <Card.Title>{mp.name}</Card.Title>
                            </LinkContainer>
                            <StarRatingComponent name={`Rating for ${mp.name} is ${mp.rating}`} value={mp.rating} editing={false}/>
                        </Card.Body>
                    </Card>
            );
            return (
                <CardColumns>
                    {cards}
                </CardColumns>
            );
        default:
            return <Loading/>;
    }
}

export const MoviePostersCardColumns = connect(mapStateToProps, mapDispatchToProps)(DisconnectedMoviePostersCardColumns);