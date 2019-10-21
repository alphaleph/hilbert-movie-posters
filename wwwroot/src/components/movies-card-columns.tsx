import React from 'react';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';
import { MoviesCardColumnsProps } from '../types/index';

// export interface IMovieForm {
//     name: string,
//     year: number
// }

export const DisconnectedMoviesCardColumns = (props: MoviesCardColumnsProps) => {
    return (
        <Container>
            <UnderConstruction pageName="MoviesCardColumns"/>
        </Container>
    );
}

export const MoviesCardColumns = DisconnectedMoviesCardColumns;