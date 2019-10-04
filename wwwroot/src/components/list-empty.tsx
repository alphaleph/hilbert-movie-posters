import React from 'react';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import { LinkContainer } from 'react-router-bootstrap';
import '../styles/components/list-empty';

export function ListEmpty() {
    return (
        <Container className="list-empty--main">
            <h3>It appears there are no movie posters available...</h3>
            <LinkContainer to="/add">
                <Button>Add A Movie Poster</Button>
            </LinkContainer>
        </Container>
    );
}
