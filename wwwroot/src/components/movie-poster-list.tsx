import React, { useEffect, useState } from 'react';
import { IMoviePosterData } from '../models/IMoviePosterData';
import { ListEmpty } from './list-empty';
import { MoviePoster } from './movie-poster';
import '../styles/components/movie-poster-list';

export interface IMoviePosterListProps {
    getMoviePostersUrl: string;
}

export function MoviePosterList(props: IMoviePosterListProps): JSX.Element {
    const [moviePosters, setMoviePosters] = useState({ isLoading: true, data: [] });

    let isListEmpty: boolean  = !moviePosters.data.length;

    async function loadMoviePosters(url: string): Promise<void> {
        try {
            await fetch(url)
                .then(response => response.json())
                .then(response => { 
                    setMoviePosters({ isLoading: false, data: response });
                    isListEmpty = !moviePosters.data.length;
                });
        } catch (e) {
            throw new Error('Error in retrieving initial movie poster data...');
        }
    }

    useEffect(() => {

        if (moviePosters.isLoading && isListEmpty) { 
            loadMoviePosters(props.getMoviePostersUrl); 
        }
    });

    return (
        <ul className="movie-posters">
            {
                isListEmpty ? <ListEmpty/> : moviePosters.data.map((moviePoster: IMoviePosterData) => (
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
