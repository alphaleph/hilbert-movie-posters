import React, { useState, useEffect } from 'react';
import MoviePoster from './movie-poster.jsx';

function MoviePosterList(props) {
    const [moviePosters, setMoviePosters] = useState([]);

    function loadMoviePosters() {
        fetch(props.url)
            .then(response => response.json())
            .then(response => setMoviePosters(response));
    }

    useEffect(() => {
        if (!moviePosters || !moviePosters.length) { 
            loadMoviePosters(); 
        }
    });

    return (
        <ul>
            {
                moviePosters.map(moviePoster => (
                    <MoviePoster key={moviePoster.id} moviePosterName={moviePoster.name} moviePosterYear={moviePoster.year} />
                ))
            }
        </ul>
    );
};

export default MoviePosterList;