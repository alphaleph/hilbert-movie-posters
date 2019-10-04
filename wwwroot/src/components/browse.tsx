import React from 'react';
import '../styles/components/browse.scss';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import { BrowserRouter as Switch, Route, RouteComponentProps } from 'react-router-dom';
import { ConnectedMoviePostersCardColumns } from './movie-posters-card-columns';
import { ConnectedMoviesCardColumns } from './movies-card-columns';

export const Browse = (props: RouteComponentProps) => {
    return (
        <Container className="browse--container my-2">
            <Col className="browse--content">
                <h1 className="my-4">
                    { props.location.pathname.endsWith('movie-posters') ? 'Movie Posters' : 'Movies' } Collection
                </h1>
                <Switch>
                    <Route path="/browse/movie-posters" component={ConnectedMoviePostersCardColumns} />
                    <Route path="/browse/movies" component={ConnectedMoviesCardColumns}/> 
                </Switch>
            </Col>
        </Container>
    );
}