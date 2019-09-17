import React from 'react';
import '../styles/components/page-not-found.scss';
import Container from 'react-bootstrap/Container';

export function PageNotFound(): JSX.Element {
    return (
        <main className="my-9">
            <Container className="page-not-found--content">
                <h1>404 page</h1>
                <h2>
                    Sorry, under construction!
                </h2>
            </Container>
        </main>
    );
}