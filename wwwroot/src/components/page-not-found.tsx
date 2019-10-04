import React from 'react';
import '../styles/components/page-not-found.scss';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export function PageNotFound() {
    return (
        <Container className="page-not-found--content my-2">
            <UnderConstruction pageName="404 Page"/>
        </Container>
    );
}