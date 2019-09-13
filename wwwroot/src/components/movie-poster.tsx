import React from 'react';

export interface MoviePosterProps {
    moviePosterName: string; 
    moviePosterYear: number;
}

function MoviePoster(props: MoviePosterProps) {
    return (
        <li>
            <p>{props.moviePosterName} ({props.moviePosterYear})</p>
        </li>
    );
};

export default MoviePoster;