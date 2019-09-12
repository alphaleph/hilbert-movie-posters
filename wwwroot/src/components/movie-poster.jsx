import React from 'react';

function MoviePoster(props) {
    return (
        <div>
            {props.moviePosterName} ({props.moviePosterYear})
        </div>
    );
};

export default MoviePoster;