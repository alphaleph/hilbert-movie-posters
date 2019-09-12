import React from 'react';
import MoviePosterList from './movie-poster-list.jsx';
import '../styles/components/home.scss';

function Home(props) {
    return (
        <main>
            <h1>Movie Posters API</h1>
            <MoviePosterList url='/api/movieposters'/>
            <h1 className="red">Hello world! Font change here too!</h1>
            <p>Font should change!</p>
        </main>
    );
}

export default Home;