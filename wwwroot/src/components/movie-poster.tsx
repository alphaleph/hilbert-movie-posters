import React from 'react';

export interface IMoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}

export function MoviePoster(props: IMoviePosterProps): JSX.Element {
    return (
        <p>{props.moviePosterName} ({props.moviePosterYear})</p>
    );
}
