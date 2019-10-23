import React, { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import StarRatingComponent from 'react-star-rating-component';
import { ReviewForm } from './review-form';
import { ReviewItemProps } from '../types/index';
import '../styles/components/review-item';

export const ReviewItem: React.FunctionComponent<ReviewItemProps> = (props: ReviewItemProps) => {
    const [isEdit, setIsEdit] = useState(false);

    const showEditForm = () => setIsEdit(true);
    const hideEditForm = () => setIsEdit(false);

    let name: string = props.name || '';
    let postedDate: Date = new Date(props.postedDate);
    let rating: number = props.rating || 0;
    let comment: string = props.comment || '';
    let moviePosterId: number = props.moviePosterId;
    let reviewId: number = props.reviewId;

    return ( 
        !isEdit ?
            <Container className="review-item__container">
                <Row className="review-item__header-row">
                    <Col>
                        <Button className="mx-2" variant="outline-dark" onClick={showEditForm} 
                                aria-label={`Edit ${name}'s Review`}>
                            Edit
                        </Button>
                        <Button variant="outline-danger" 
                                aria-label={`Delete ${name}'s Review`}>
                            Delete
                        </Button>
                    </Col>
                </Row>
                <Row className="review-item__content-row">
                    <Col>
                        <h3 className="review-item__reviewer-name">{name}</h3>
                        <StarRatingComponent name="Sample rating" value={rating} editing={false}/>
                        <p>{comment}</p>
                    </Col>
                </Row>
                <Row className="review-item__footer-row">
                    <Col>
                        <p className="text-muted">
                            Posted on: {`${postedDate.toDateString()} ${postedDate.toLocaleTimeString()}`}
                        </p>
                    </Col>
                </Row>
            </Container>
        : <ReviewForm initEmpty={false} handleCancel={hideEditForm} 
                                    name={name} rating={rating} comment={comment} />
    );
}