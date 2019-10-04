import React from 'react';
import '../styles/components/home';
import { ConnectedMoviePostersCarousel } from './movie-posters-carousel';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import { LinkContainer } from 'react-router-bootstrap';

export function Home() {
    return (
            <Container fluid className="home home--content">
                <Container className="home--content-container">
                    <ConnectedMoviePostersCarousel/>
                    <h1 className="mt-5"><strong>Welcome to Hilbert.</strong></h1>
                    <h2 className="mt-2">Your center for the world of movie posters</h2>
                    <Jumbotron className="home--jumbotron py-5">
                        <h2><strong>Behind every great movie... <br/>is a great poster.</strong></h2>
                        <p>Explore. Contribute to the discussion. Search for inspiration. <strong>Hilbert</strong> is your source and community for the time-honored art.</p>
                    </Jumbotron>
                    <section className="home--browse-banner py-5">
                        <Container className="home--browse-banner-content">
                            <h2 className="home--browser-banner-header"><strong>Take a look at our selection.</strong></h2>
                            <div className="home--browse-banner-button-group">
                                <div className="home--browse-banner-button-wrapper">
                                    <LinkContainer to="/browse">
                                        <Button variant="primary" size="lg" className="home--browse-banner-button">Browse Movie Posters</Button>
                                    </LinkContainer>
                                </div>
                                <div className="home--browse-banner-button-wrapper">
                                    <LinkContainer to="/browse/movies">
                                        <Button variant="primary" size="lg" className="home--browse-banner-button">Browse Movies</Button>
                                    </LinkContainer>
                                </div>
                            </div>
                        </Container>
                    </section>
                </Container>
            </Container>
    );
}
