import React from 'react';
import '../styles/components/browse.scss';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export function Browse() {
    return (
        <main className="my-2">
            <UnderConstruction pageName="Browse"/>
        </main>
    );
}