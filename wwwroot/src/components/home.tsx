import React from 'react';
import '../styles/components/home';
import { MoviePosterList } from './movie-poster-list';

export function Home(): JSX.Element {
    return (
        <main className="home">
            <h1>Movie Posters API</h1>
            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
        </main>
    );
}
