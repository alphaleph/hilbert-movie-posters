import React from 'react';

export interface IMoviePosterProps {
    moviePosterName: string;
    moviePosterYear: number;
}

export function MoviePoster(props: IMoviePosterProps): JSX.Element {
    return (
        <li>
            <p>{props.moviePosterName} ({props.moviePosterYear})</p>
        </li>
    );
}
