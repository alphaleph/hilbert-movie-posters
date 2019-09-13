import React from 'react';
import '../styles/components/home.scss';
import { MoviePosterList } from './movie-poster-list';

export function Home() {
    return (
        <main>
            <h1>Movie Posters API</h1>
            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
            <h1 className="red">Hello world! Font change here too!</h1>
            <p>Font should change!</p>
        </main>
    );
}
