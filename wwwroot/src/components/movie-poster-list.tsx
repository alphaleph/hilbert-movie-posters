import React, { useEffect, useState } from 'react';
import { ListEmpty } from './list-empty';
import { MoviePoster } from './movie-poster';

export interface IMoviePosterListProps {
    getMoviePostersUrl: string;
}

export function MoviePosterList(props: IMoviePosterListProps) {
    const [moviePosters, setMoviePosters] = useState([]);

    const isListEmpty: boolean  = !moviePosters.length;

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
                isListEmpty ? <ListEmpty/> : moviePosters.map(moviePoster => (
                        <MoviePoster 
                            key={moviePoster.id} 
                            moviePosterName={moviePoster.name} 
                            moviePosterYear={moviePoster.year} 
                        />
                    ))
            }
        </ul>
    );
}
