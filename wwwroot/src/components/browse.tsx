import React from 'react';
import '../styles/components/browse.scss';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import { BrowserRouter as RouteComponentProps } from 'react-router-dom';
import { MoviePostersCardColumns } from './movie-posters-card-columns';
import { MoviesCardColumns } from './movies-card-columns';

export const Browse = (props: RouteComponentProps) => {
    return (
        <Container className="browse--container my-2">
            <Col className="browse--content">
                <h1 className="my-4">
                    { props.location.pathname.endsWith(`/browse/movie-posters`) ? 'Movie Posters' : 'Movies' } Collection
                </h1>
                { 
                    props.location.pathname.endsWith(`/browse/movie-posters`) ? <MoviePostersCardColumns/> : <MoviesCardColumns/>
                }
            </Col>
        </Container>
    );
}