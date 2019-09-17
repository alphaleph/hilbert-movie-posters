import React from 'react';
import '../styles/components/home';
import { MoviePosterList } from './movie-poster-list';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export function Home(): JSX.Element {
    return (
        <main className="home">
            <Container fluid="true" className="home--content">
                <h1 className="mt-3"><strong>Welcome to Hilbert.</strong></h1>
                <h2 className="mt-3">Your center for the world of movie posters</h2>
                <Container>
                    <Row className="mt-5">
                        <Col xs={12} md={8}>
                            <MoviePosterList getMoviePostersUrl='/api/movieposters'/>
                        </Col>
                        <Col xs={12} md={4}>
                            <Jumbotron className="home--jumbotron py-2 my--md-5">
                                <h2><strong>Behind every great movie... <br/>is a great poster.</strong></h2>
                                <p>Explore. Contribute to the discussion. Search for inspiration. <strong>Hilbert</strong> is your source and community for the time-honored art.</p>
                            </Jumbotron>
                        </Col>
                    </Row>
                </Container>
            </Container>
        </main>
    );
}
