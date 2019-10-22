import React, { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
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
        <Container>
            <Row>
                <Col>
                    { !isEdit ?
                        <div>
                            <Button onClick={showEditForm}>Edit</Button>
                            <Button>Delete</Button>
                            <p>A Review Item here...</p>
                            <p>Posted on: {`${postedDate.toDateString()} ${postedDate.toLocaleTimeString()}`}</p>
                            <p>Name: {name}</p>
                            <p>Rating: {rating}</p>
                            <p>Comment: {comment}</p>
                        </div>
                        : <ReviewForm initEmpty={false} handleCancel={hideEditForm} 
                                      name={name} rating={rating} comment={comment} />
                    }
                </Col>
            </Row>
        </Container>
    );
}