import React from 'react';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export const DisconnectedReviewsList = () => {
    return (
        <Container>
            <UnderConstruction pageName="Reviews List"/>
        </Container>
    );
}

export const ReviewsList = DisconnectedReviewsList;