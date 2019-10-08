import React from 'react';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export const DisconnectedMovieView = () => {
    //TODO: Check for movie posters in state based on moviePosterId in URL, if not present, then download
    return (
        <Container>
            <UnderConstruction pageName="MovieView"/>
        </Container>
    );
}

export const MovieView = DisconnectedMovieView;