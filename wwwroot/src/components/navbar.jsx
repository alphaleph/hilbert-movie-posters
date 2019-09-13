import React from 'react';
import '../styles/components/navbar.scss';

function NavBar(props) {
    return (
        <nav id="navbar-main">
            <div className="nav-logo-container">
                <a href="https://localhost:5001/home">
                    <img alt="Movie Posters Homepage" src="../apple-touch-icon.png"/>
                </a>
            </div>
            <ul className="left-group">
                <li>Left Button</li>
                <li>Left Button #2</li>
            </ul>
            <ul className="right-group">
                <li>Right Button</li>
                <li>Right Button #2</li>
            </ul>
        </nav>
    );
}

export default NavBar;