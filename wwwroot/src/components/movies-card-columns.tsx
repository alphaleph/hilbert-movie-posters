import React from 'react';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export const MoviesCardColumns = () => {
    return (
        <Container>
            <UnderConstruction pageName="MoviesCardColumns"/>
        </Container>
    );
}

export const ConnectedMoviesCardColumns = MoviesCardColumns;