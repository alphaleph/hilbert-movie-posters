import React from 'react';
import ReactDOM from 'react-dom';
import MoviePosterList from './components/movie-poster-list.jsx';

function App(props) {

    return (
            <div>
                <MoviePosterList url = '/api/movieposters' />
            </div>
    );
}

ReactDOM.render(
    <App />,
    document.querySelector('#container')
);

module.hot.accept();