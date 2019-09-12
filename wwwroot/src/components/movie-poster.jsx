import React from 'react';

function MoviePoster(props) {
    return (
        <li>
            <p>{props.moviePosterName} ({props.moviePosterYear})</p>
        </li>
    );
};

export default MoviePoster;