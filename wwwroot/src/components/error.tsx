import React from 'react';
import { connect } from 'react-redux';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { apiRecover } from '../redux/actions';
import { ErrorProps, MainMoviePostersListUiState } from '../types/index';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import '../styles/components/error';

const mapStateToProps = (state: MainMoviePostersListUiState) => {
    return {
        error: state.error
    }
}

const mapDispatchToProps = {
    apiRecover
}

export const DisconnectedError = (props: ErrorProps) => {
    const handleReload = () => {
        props.apiRecover();
        props.history.goBack();
    }

    return (
        <Container className="error__content text-center px-0">
            <Row>
                <Col>
                    <h1 className="error__page-title">
                        An error has occurred...
                    </h1>
                    <FontAwesomeIcon className="error__icon" icon="cat" size="7x"/>
                    <h2 className="py-4">
                        {(props.error) ? `Error message: ${props.error.code} ${props.error.message} ` : `Please return via the button below.`}
                    </h2>
                    <Button className="error__reload-back-button" variant="warning" size="lg" onClick={handleReload}>Reload Back</Button>
                </Col>
            </Row>
        </Container>
    );
}

export const Error = connect(mapStateToProps, mapDispatchToProps)(DisconnectedError);