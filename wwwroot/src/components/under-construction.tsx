import React from 'react';
import { UnderConstructionProps } from '../types/index';
import Container from 'react-bootstrap/Container';
import { FoldingCube } from './folding-cube';
import '../styles/components/under-construction';

export const UnderConstruction = (props: UnderConstructionProps) => {
    return (
        <Container className="under-construction--content">
            <h1 className="under-construction--page-title">{props.pageName + ' Page'}</h1>
            <h2 className="py-4">
                Sorry, under construction!
            </h2>
            <Container className="under-construction--spinner-container py-5">
                <FoldingCube/>
                <h1>
                    Pardon the dust...
                </h1>
            </Container>
        </Container>
    );
} 