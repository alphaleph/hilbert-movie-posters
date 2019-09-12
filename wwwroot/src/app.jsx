import React from 'react';
import ReactDOM from 'react-dom';
import MoviePosterList from './components/movie-poster-list.jsx';
import './styles/style.scss';

function App(props) {
    return (
            <div>
                <h1>Movie Posters API</h1>
                <MoviePosterList url='/api/movieposters'/>
                <h1 className="red">Hello world! Font change here too!</h1>
                <p>Font should change!</p>
            </div>
    );
}

ReactDOM.render(
    <App />,
    document.querySelector('#app')
);

module.hot.accept();