import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Home } from './components/home';
import { NavBar } from './components/navbar';
import { SiteMap } from './components/site-map';
import { About } from './components/about';
import { Browse } from './components/browse';
import { AddMoviePoster } from './components/add-movie-poster';
import { Login } from './components/login';
import { Signup } from './components/signup';
import { PageNotFound } from './components/page-not-found';
import './styles/style.scss';
import './styles/components/app';
import 'bootstrap';

const App = () => {
    return (
        <Router>
            <div id="app">
                <NavBar/>
                <Switch>
                    <Route path="/" exact component={Home} />
                    <Route path="/home" exact component={Home}/>
                    <Route path="/browse" component={Browse} />
                    <Route path="/add" component={AddMoviePoster} />
                    <Route path="/login" component={Login} />
                    <Route path="/signup" component={Signup} />
                    <Route path="/about" component={About} />
                    <Route component={PageNotFound} />
                </Switch>
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
