import React from 'react';
import '../styles/components/add-movie-poster.scss';
import Container from 'react-bootstrap/Container';
import { UnderConstruction } from './under-construction';

export function AddMoviePoster() {
    return (
        <main className="my-2">
            <UnderConstruction pageName="Add A Poster"/>
        </main>
    );
}