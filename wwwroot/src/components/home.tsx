import React from 'react';
import '../styles/components/home';
import { MoviePostersCarousel } from './movie-posters-carousel';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import { LinkContainer } from 'react-router-bootstrap';

export function Home() {
    return (
        <Container fluid className="home home__content">
            <Container className="home__content-container">
                <section className="home__title-banner">
                    <h1 className="pt-5"><strong>Welcome to Hilbert.</strong></h1>
                    <h2 className="pt-2 pb-5">Your center for the world of movie posters.</h2>
                    <div className="dark-step-line"></div>
                </section>
                <MoviePostersCarousel/>
                <Jumbotron className="home__jumbotron py-5">
                    <h2>Behind every great movie... is a great poster.</h2>
                    <p>Explore. Contribute to the discussion. Search for inspiration.</p>
                    <p><strong>Hilbert</strong> is your source and community for the time-honored art.</p>
                </Jumbotron>
                <section className="home__browse-banner py-5">
                    <Container className="home__browse-banner-content">
                        <h2 className="home__browser-banner-header"><strong>Take a look at our selection.</strong></h2>
                        <div className="home__browse-banner-button-group">
                            <div className="home__browse-banner-button-wrapper">
                                <LinkContainer to="/browse/movie-posters">
                                    <Button variant="primary" size="lg" className="home__browse-banner-button">Browse Movie Posters</Button>
                                </LinkContainer>
                            </div>
                            <div className="home__browse-banner-button-wrapper">
                                <LinkContainer to="/browse/movies">
                                    <Button variant="primary" size="lg" className="home__browse-banner-button">Browse Movies</Button>
                                </LinkContainer>
                            </div>
                        </div>
                    </Container>
                </section>
            </Container>
        </Container>
    );
}
