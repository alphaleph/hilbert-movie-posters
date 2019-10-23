import React from 'react';
import Container from 'react-bootstrap/Container';
import '../styles/components/list-empty';

export function ListEmpty() {
    return (
        <Container className="list-empty__main mt-3 mb-4">
            <h3>It appears there are no items available...</h3>
        </Container>
    );
}
