import React from "react";
import '../styles/components/about';

export function About(): JSX.Element {
    return (
        <main className="about--main">
            <h1>
                Welcome to the Hilbert Movie Posters Collection!
            </h1>
            <blockquote cite="https://quoteinvestigator.com/2016/06/20/books/">
                <p>I cannot remember the books I've read any more than the meals I have eaten; even so, they have made me.</p>
                <footer>-- Ralph Waldo Emerson</footer>
            </blockquote>
            <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>
        </main>
    );
}