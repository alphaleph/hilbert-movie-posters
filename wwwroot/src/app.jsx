import React from 'react';
import ReactDOM from 'react-dom';
import MoviePosterList from './components/movie-poster-list.jsx';
import styles from './styles/style.scss';

function App(props) {
    return (
            <div>
                <MoviePosterList url='/api/movieposters'/>
                <h2 className="red">Hello world!</h2>
            </div>
    );
}

ReactDOM.render(
    <App />,
    document.querySelector('#container')
);

module.hot.accept();