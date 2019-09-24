import React from 'react';
import { MoviePosterProps } from '../types/index';

export function MoviePoster(props: MoviePosterProps) {
    return (
        <p>{props.moviePosterName} ({props.moviePosterYear})</p>
    );
}
