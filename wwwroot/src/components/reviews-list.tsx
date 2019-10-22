import React, { useState } from 'react';
import { connect } from 'react-redux';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { IReviewData, IMoviePosterData } from '../types/api_models';
import { AppState, ReviewsListProps, ReviewsListOwnProps, ReviewsListStateProps } from '../types/index';
import { ReviewItem } from './review-item';
import { ReviewForm } from './review-form';
import { Error } from './error';
import { ListEmpty } from './list-empty';
import { selectMoviePosters } from '../redux/selectors';
import '../styles/components/reviews-list';

const mapStateToProps = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

export const DisconnectedReviewsList: React.FunctionComponent<ReviewsListProps> = (props: ReviewsListProps) => {
    const [isAddReview, setIsAddReview] = useState(false);

    const showAddReview = () => setIsAddReview(true);
    const hideAddReview = () => setIsAddReview(false);

    const moviePoster = (props as ReviewsListStateProps).moviePostersList.find( 
                            (mp: IMoviePosterData) => mp.moviePosterId === (props as ReviewsListOwnProps).moviePosterId
                        );
    const reviews: IReviewData[] | null = (moviePoster) ? moviePoster.reviews : null;

    if (!reviews) {
        return <Error history={(props as ReviewsListOwnProps).history}/>;
    } 

    return (
        <Container>
            <Row>
                <Col>
                    { reviews.length ? 
                        <ul>
                            {
                                reviews.map( (r: IReviewData) => (
                                    <li key={r.reviewId}>
                                        <ReviewItem name={r.name} postedDate={r.postedDate} 
                                                    rating={r.rating} comment={r.comment}
                                                    moviePosterId={r.moviePosterId} reviewId={r.reviewId}/>
                                    </li>
                                ))
                            }
                            <li>
                                {
                                  isAddReview ? <ReviewForm initEmpty={true} handleCancel={hideAddReview}/>
                                              : <Button variant="dark" onClick={showAddReview}>Add A Review</Button>
                                }
                            </li>
                        </ul>
                        :
                        <ListEmpty/>
                    }
                </Col>
            </Row>
        </Container>
    );
}

export const ReviewsList = connect(mapStateToProps, null)(DisconnectedReviewsList);