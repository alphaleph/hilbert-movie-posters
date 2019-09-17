import React from 'react';
import { Link } from 'react-router-dom'; 
import '../styles/components/site-map';
import './about';

export function SiteMap(): JSX.Element {
    return (
        <nav className="site-map--main py-5">
            <ul>
                <li>
                    <Link to="/about">About</Link>
                </li>
                <li>
                    <a href="https://github.com/chaua0927/movie-posters">GitHub</a>
                </li>
            </ul>
        </nav>
    );
}