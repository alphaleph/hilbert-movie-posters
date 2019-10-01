import React from 'react';
import { Container } from 'react-bootstrap';
import '../styles/components/error';

export const Error = () => {
    return (
        <Container className="error--main">
            <h1>
                An error has occurred...
            </h1>
        </Container>
    );
}