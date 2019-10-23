import React, { useState } from 'react';
import { ReviewFormProps } from '../types/index';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import StarRatingComponent from 'react-star-rating-component'; 
import { requestAddReview } from '../redux/actions';
import '../styles/components/review-form';

// export interface IReviewForm {
//     name: string,
//     rating: number,
//     comment?: string
// }

export const ReviewForm = (props: ReviewFormProps) => {
    let defaultName = '';
    let defaultRating = 0;
    let defaultComment = '';

    if (!props.initEmpty) {
        defaultName = props.name || defaultName;
        defaultRating = props.rating || defaultRating;
        defaultComment = props.comment || defaultComment;
    }

    const [name, setName] = useState(defaultName);
    const [rating, setRating] = useState(defaultRating);
    const [cooment, setComment] = useState(defaultComment);
    const [validated, setValidated] = useState(false);


    const handleStarClick = (nextValue: number, prevValue: number, name: string) => {
        setRating(nextValue);
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>): void => {
        event.preventDefault();
        const form = event.currentTarget;

        if (!form.checkValidity()) { 
            event.stopPropagation();
        }
        
        setValidated(true);
        //Dispatch submission
        //Notify user of submission
    }

    return (
        <Container>
            <Row className="review-form__header-row">
                <Col>
                    <Button className="mx-2" variant="outline-dark" onClick={props.handleCancel} 
                            aria-label={`Close Review Form`}>
                        X
                    </Button>
                </Col>
            </Row>
            <Row className="review-form__content-row">
                <Col>
                    <p>* indicates required fields</p>
                    <Form noValidate validated={validated} onSubmit={handleSubmit}>
                        <Form.Row>
                            <Form.Group as={Col} controlId="formName">
                                <Form.Label>Name*</Form.Label>
                                <Form.Control
                                    required
                                    type="text"
                                    placeholder="Enter your name"
                                    defaultValue={defaultName}
                                />
                                <Form.Control.Feedback type="invalid">Please provide a name.</Form.Control.Feedback>
                            </Form.Group>
                            <Form.Group as={Col} controlId="formRating">
                                <Form.Label>Rating*</Form.Label>
                                <StarRatingComponent name="rating" value={rating} onStarClick={handleStarClick}/>
                            </Form.Group>
                            <Form.Group as={Col} controlId="formComment">
                                <Form.Label>Comment</Form.Label>
                                <Form.Control
                                    as="textarea"
                                    rows="3"
                                    defaultValue={defaultComment}
                                />
                            </Form.Group>
                        </Form.Row>
                        <Button className="mx-2" variant="primary" type="submit" 
                            aria-label={`Submit Review Form`}>
                            Submit
                        </Button>
                        <Button className="mx-2" variant="outline-dark" onClick={props.handleCancel} 
                                aria-label={`Cancel Review Form`}>
                            Cancel
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
}