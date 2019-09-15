import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';
import { Home } from './components/home';
import { NavBar } from './components/navbar';
import { SiteMap } from './components/site-map';
import './styles/style.scss';

function App(): JSX.Element {
    return (
        <Router>
            <div id="app">
                <NavBar/>
                <Home/>
                <SiteMap/>
            </div>
        </Router>
    );
}

ReactDOM.render(
    <App />,
    document.querySelector('#container') as HTMLElement,
);

// For Webpack HMR
module.hot.accept();
