import React from 'react';
import '../styles/components/site-map'

export function SiteMap(): JSX.Element {
    return (
        <nav className="site-map--main">
            <ul>
                <li>
                    <a href="/about">About</a>
                </li>
                <li>
                    <a href="https://github.com/chaua0927/movie-posters">GitHub</a>
                </li>
            </ul>
        </nav>
    );
}