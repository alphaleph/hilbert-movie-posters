import React from 'react';
import ReactDOM from 'react-dom';
import { Home } from './components/home';
import { NavBar } from './components/navbar';
import './styles/style.scss';

function App() {
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
    document.querySelector('#container') as HTMLElement,
);

// For Webpack HMR
module.hot.accept();
