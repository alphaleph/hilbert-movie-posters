import React from 'react';
import { Container } from 'react-bootstrap';
import '../styles/components/loading';

export const Loading = () => {
    return (
        <Container className="loading--main">
            <h1>
                Loading...
            </h1>
        </Container>
    );
}