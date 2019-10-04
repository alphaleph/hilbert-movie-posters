import React, { useEffect } from 'react';
import { withRouter } from 'react-router';

const ScrollToTopHandler = ( { children, location, history: { action } }) => {
    useEffect(() => {
        if (action === 'PUSH') {
            window.scrollTo(0, 0);
        }
    }, [location.pathname]);

    return (
        children || null
    );
}

export const ScrollToTop = withRouter(ScrollToTopHandler);