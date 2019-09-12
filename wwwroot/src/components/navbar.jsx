import React from 'react';
import '../styles/components/navbar.scss';

function NavBar(props) {
    return (
        <nav>
            <ul className="left-group">
                <li>Left Button</li>
                <li>Left Button #2</li>
            </ul>
            <button>Logo</button>
            <ul className="right-group">
                <li>Right Button</li>
                <li>Right Button #2</li>
            </ul>
        </nav>
    );
}

export default NavBar;