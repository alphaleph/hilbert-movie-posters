import React from 'react';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import { RouteComponentProps } from 'react-router-dom';
import { MoviePostersCardColumns } from './movie-posters-card-columns';
import { MoviesCardColumns } from './movies-card-columns';
import { Breadcrumb } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../styles/components/browse.scss';

export const Browse = (props: RouteComponentProps) => {

    let isViewingMoviePosters: boolean = props.location.pathname.endsWith(`/browse/movie-posters`);

    return (
        <Container className="browse__container my-2">
            <Row className="pt-2">
                <Col md={6}>
                    <Breadcrumb>
                        <Breadcrumb.Item active className="mb-0">Browse / </Breadcrumb.Item>
                    </Breadcrumb>
                </Col>
                <Col className="browse__browse-by-movie-button" md={6}>
                    <LinkContainer to={ isViewingMoviePosters ? `/browse/movies` : `/browse/movie-posters`}>
                        <Button variant="dark">Browse by { isViewingMoviePosters ? `Movie` : `Movie Poster` }</Button>
                    </LinkContainer>
                </Col>
            </Row>
            <Row>
                <Col className="browse__content">
                    <h1 className="mt-2 mb-5">
                        { isViewingMoviePosters ? 'Movie Posters' : 'Movies' } Collection
                    </h1>
                    { 
                        isViewingMoviePosters ? <MoviePostersCardColumns history={props.history}/> 
                                              : <MoviesCardColumns history={props.history}/>
                    }
                </Col>
            </Row>
        </Container>
    );
}