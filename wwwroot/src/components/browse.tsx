import React from 'react';
import '../styles/components/browse.scss';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import { ConnectedMoviePostersCardColumns } from './movie-posters-card-columns';

export function Browse() {
    return (
        <Container className="browse--container my-2">
            <Col className="browse--content">
                <ConnectedMoviePostersCardColumns/>
            </Col>
        </Container>
    );
}