import React from 'react';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export const DisconnectedMoviesCardColumns = () => {
    return (
        <Container>
            <UnderConstruction pageName="MoviesCardColumns"/>
        </Container>
    );
}

export const MoviesCardColumns = DisconnectedMoviesCardColumns;