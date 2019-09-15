import React from 'react';
import '../styles/components/navbar.scss';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';

export function NavBar(): JSX.Element {
    return (
        <nav className="navbar--main">
            <div className="nav-logo-container">
                <a href="https://localhost:5001/home">
                    <img alt="Movie Posters Homepage" src="../apple-touch-icon.png"/>
                </a>
            </div>
            <ul className="left-group">
                <ButtonGroup>
                    <Button variant="primary">Left Button #1</Button>
                    <Button variant="secondary">Left Button #2</Button>
                </ButtonGroup>
            </ul>
            <ul className="right-group">
                <ButtonGroup>
                    <Button variant="primary">Right Button #1</Button>
                    <Button variant="secondary">Right Button #2</Button>
                </ButtonGroup>
            </ul>
        </nav>
    );
}
