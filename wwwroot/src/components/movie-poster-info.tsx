import React from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import StarRatingComponent from 'react-star-rating-component';
import { MoviePosterInfoProps } from '../types/index';

export const MoviePosterInfo = (props: MoviePosterInfoProps) => {
    return (
        <Container className="movie-poster-view__info-container my-3 px-4 py-2">
            <Row>
                <Col>
                    <StarRatingComponent name="Sample rating" value={props.rating}/>
                </Col>
                <Col>
                    <p className="movie-poster-view__info-text ">Total Ratings: {props.ratingCount}</p>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h3 className="movie-poster-view__info-header">Artist</h3>
                    <p className="movie-poster-view__info-text">{props.artist}</p>
                </Col>
                <Col>
                    <h3 className="movie-poster-view__info-header">Year</h3>
                    <p className="movie-poster-view__info-text">{props.year}</p>
                </Col>
            </Row>
        </Container>
    );
}