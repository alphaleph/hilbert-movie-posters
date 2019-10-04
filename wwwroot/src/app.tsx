import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { Store } from './redux/store';
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
import { SkipLink } from './components/skip-link';
import { ConnectedMoviePosterView } from './components/movie-poster-view';
// import { MovieView } from './components/movie-view';
import './styles/style.scss';
import './styles/components/app';
import 'bootstrap';

const App = () => {
    return (
        <Router>
            <div id="app">
                <SkipLink/>
                <NavBar/>
                <main id="main-content" tabIndex={-1}>
                    <Switch>
                        <Route path="/" exact component={Home} />
                        <Route path="/home" exact component={Home}/>
                        <Route path="/browse" component={Browse} />
                        <Route path="/add" component={AddMoviePoster} />
                        <Route path="/login" component={Login} />
                        <Route path="/signup" component={Signup} />
                        <Route path="/about" component={About} />
                            <Route path="/movie-posters" component={ConnectedMoviePosterView} />
                            {/* <Route path="/movies" component={MovieView} /> */}
                        <Route component={PageNotFound} />
                    </Switch>
                </main>
                <SiteMap/>
            </div>
        </Router>
    );
}

ReactDOM.render(
    <Provider store={Store}>
    <App />
    </Provider>,
    document.querySelector('#container') as HTMLElement,
);

// For Webpack HMR
module.hot.accept();
