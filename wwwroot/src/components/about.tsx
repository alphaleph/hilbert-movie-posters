import React from "react";
import '../styles/components/about';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export function About() {
    return (
        <Container className="about__main about__container">
            <h1 className="pt-5 mt-4 mb-5">
                <strong>Welcome to the Hilbert Movie Posters Collection!</strong>
            </h1>
            <Container>
                <Row>
                    <Col className="text-center my-2">
                        <img
                            className="about__img"
                            src="/le_voyage_dans_la_lune.png" 
                            alt="Le Voyage Dans La Lune - Moonface with Rocket in Eye"
                            height=""
                            />
                    </Col>
                    <Col lg={6} className="about__text my-5 mr-lg--5">
                        <blockquote cite="https://quoteinvestigator.com/2016/06/20/books/">
                            <p>I cannot remember the books I've read any more than the meals I have eaten; even so, they have made me.</p>
                            <footer className="about__quote-citation"><i>-- Ralph Waldo Emerson</i></footer>
                        </blockquote>
                        <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </Col>
                </Row>
            </Container>
        </Container>
    );
}