import React from 'react';
import Button from 'react-bootstrap/Button';
import '../styles/components/skip-link';

export const SkipLink = () => {
    const handleClick = (e: React.MouseEvent) => {
        e.preventDefault();
        let mainContent: HTMLElement | null = document.querySelector('#main-content');
        if (mainContent !== null) {
            mainContent.focus();
        }
    }

    return (
        <Button id="skip-link" variant="link" onClick={handleClick}>
            Skip to Main Content
        </Button>
    );
}