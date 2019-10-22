import React from 'react';
import { ReviewFormProps } from '../types/index';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { requestAddReview } from '../redux/actions';
import '../styles/components/review-form';

// export interface IReviewForm {
//     name: string,
//     rating: number,
//     comment?: string
// }

export const ReviewForm = (props: ReviewFormProps) => {
    let name: string = props.name || '';
    let rating: number = props.rating || 0;
    let comment: string = props.comment || '';

    return (
        <Container>
            <Row>
                <Col>
                    <p>Review Form...</p>
                    <p>Name: {name}</p>
                    <p>Rating: {rating}</p>
                    <p>Comment: {comment}</p>
                    <Button>Submit</Button>
                    <Button onClick={props.handleCancel}>Cancel</Button>
                </Col>
            </Row>
        </Container>
    );
}