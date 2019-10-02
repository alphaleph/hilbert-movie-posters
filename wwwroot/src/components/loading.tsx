import React from 'react';
import { Container } from 'react-bootstrap';
import { FoldingCube } from './folding-cube';
import '../styles/components/loading';

export const Loading = () => {
    return (
        <Container className="loading--main py-5">
            <FoldingCube/>
            <h1>
                Loading...
            </h1>
        </Container>
    );
}