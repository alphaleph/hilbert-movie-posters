import React, { useState, useEffect } from 'react';
import MoviePoster from './movie-poster';
import ListEmpty from './list-empty'

export interface MoviePosterListProps {
    getMoviePostersUrl: string
}

function MoviePosterList(props: MoviePosterListProps) {
    const [moviePosters, setMoviePosters] = useState([]);
    
    const isListEmpty: boolean  = !moviePosters.length

    function loadMoviePosters(url: string) {
        fetch(url)
            .then(response => response.json())
            .then(response => setMoviePosters(response));
    }

    useEffect(() => {
        if (isListEmpty) { 
            loadMoviePosters(props.getMoviePostersUrl); 
        }
    });

    return (
        <ul>
            {
                isListEmpty 
                    ? <ListEmpty/> 
                    : moviePosters.map(moviePoster => (
                        <MoviePoster key={moviePoster.id} 
                            moviePosterName={moviePoster.name} 
                            moviePosterYear={moviePoster.year} 
                        />
                    ))
            }
        </ul>
    );
};

export default MoviePosterList;