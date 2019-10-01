import React from 'react';
import { Container } from 'react-bootstrap';
import '../styles/components/whoops';

export const Whoops = () => {
    return (
        <Container className="whoops--main">
            <h1>
                Whoops... you shouldn't be here...
            </h1>
        </Container>
    );
}