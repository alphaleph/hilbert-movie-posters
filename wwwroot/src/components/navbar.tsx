import React from 'react';
import '../styles/components/navbar.scss';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import { LinkContainer } from 'react-router-bootstrap'; 


export function NavBar() {
    return (
        <nav className="app-block navbar--main">
                <div className="nav-logo-container">
                    <Link to="/">
                        <img className="logo-img" alt="Movie Posters Homepage" src="../apple-touch-icon.png"/>
                    </Link>
                </div>
            <ul className="left-group">
                <li>
                    <LinkContainer to="/browse">
                        <Button variant="primary">Browse</Button>
                    </LinkContainer>
                </li>
                <li>
                    <LinkContainer to="/add">
                        <Button variant="secondary">Add A Movie</Button>
                    </LinkContainer>
                </li>
            </ul>
            <ul className="right-group">
                <li>
                    <LinkContainer to="/login">
                        <Button variant="outline-info">Log In</Button>
                    </LinkContainer>
                </li>
                <li>
                    <LinkContainer to="/signup">
                        <Button variant="info">Sign Up</Button>
                    </LinkContainer>
                </li>
            </ul>
        </nav>
    );
}
