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
import { MoviePosterView } from './components/movie-poster-view';
import { MovieView } from './components/movie-view';
import { ScrollToTop } from './components/scroll-to-top';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCat } from '@fortawesome/free-solid-svg-icons';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import './styles/style.scss';
import './styles/components/app';
import 'bootstrap';

library.add(faCat);

const App = () => {
    return (
        <Router>
            <ScrollToTop>
                <Container fluid={true} id="app" className="text-center">
                    <SkipLink/>
                    <NavBar/>
                    <Row id="main-container">
                        <Col className="main__col">
                            <main id="main-content" tabIndex={-1}>
                                <Switch>
                                    <Route path="/" exact component={Home} />
                                    <Route path="/home" exact component={Home}/>
                                    <Route path="/browse" component={Browse} />
                                    <Route path="/add" component={AddMoviePoster} />
                                    <Route path="/login" component={Login} />
                                    <Route path="/signup" component={Signup} />
                                    <Route path="/about" component={About} />
                                    <Route path="/view/movie-posters/:id" component={MoviePosterView} />
                                    <Route path="/view/movies/:id" component={MovieView} />
                                    <Route component={PageNotFound} />
                                </Switch>
                            </main>
                        </Col>
                    </Row>
                    <SiteMap/>
                </Container>
            </ScrollToTop>
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
