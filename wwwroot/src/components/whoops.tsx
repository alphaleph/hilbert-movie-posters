import React from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';
import '../styles/components/whoops';

export const Whoops = () => {
    return (
        <Container className="whoops__main">
            <Row>
                <Col>
                    <h1 className="mt-5">
                        Whoops... There's a problem with the page.
                    </h1>
                    <p className="whoops__caption">
                        <span className="whoops__caption-whale"><em>Whale</em></span> that's embarrassing...
                    </p>
                    <Image fluid src="https://res.cloudinary.com/chaua0927/image/upload/v1570710884/hilbert-poster-images/ncrbfqyxodsxivbaiely.png"/>
                </Col>
            </Row>
        </Container>
    );
}