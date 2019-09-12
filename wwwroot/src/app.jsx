import React from 'react';
import ReactDOM from 'react-dom';
import Home from './components/home.jsx';
import NavBar from './components/navbar.jsx';
import './styles/style.scss';

function App(props) {
    return (
        <div id="app">
            <NavBar/>
            <Home/>
            <aside className="aside-left">
                <p>Left Aside</p>
            </aside>
            <aside className="aside-right">
                <p>Right Aside</p>
            </aside>
            <footer>
                <p>Site Map</p>
            </footer>
        </div>
    );
}

ReactDOM.render(
    <App />,
    document.querySelector('#container')
);

module.hot.accept();