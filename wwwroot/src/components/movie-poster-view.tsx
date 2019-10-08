import React from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePosterViewProps } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { requestGetMoviePosters } from '../redux/actions';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';
import Row from 'react-bootstrap/Row';
import StarRatingComponent from 'react-star-rating-component';
import { Loading } from './loading';
import { Error } from './error';
import { ReviewsList } from './reviews-list';
import '../styles/components/movie-poster-view.scss';
import { Breadcrumb } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

const mapStateToProps = (state: AppState) => {
    return {
        availableMoviePosters: state.ui.mainMoviePostersList.moviePosters,
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const DisconnectedMoviePosterView: React.FunctionComponent<MoviePosterViewProps> = (props: MoviePosterViewProps) => {
    
    // if (props.listState === UI_INIT) {
    //     console.log("Requesting....");
    //     props.requestGetMoviePosters();
    // }

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error/>;
        case UI_LOADED:
            //TODO: Check for individual movie poster in state based on moviePosterId in URL, if not present, then download    
            // if (props.availableMoviePosters.includes(parseInt(props.match.params.id))) {
                const mp: IMoviePosterData | undefined = props.moviePostersList.find(mp => mp.moviePosterId === parseInt(props.match.params.id, 10));
            // }
            if (mp === undefined) {
                return <Error/>;
            }

            return (
                <Container className="movie-poster-view__container my-2">
                    <Breadcrumb className="movie-poster-view__breadcrumb">
                        <LinkContainer to="/browse/movie-posters">
                            <Breadcrumb.Item>Browse Movie Posters</Breadcrumb.Item>
                        </LinkContainer>
                        <Breadcrumb.Item active>{mp.name}</Breadcrumb.Item>
                    </Breadcrumb>
                    <h1 className="movie-poster-view__header mt-2 mb-5">{mp.name}</h1>
                    <Row>
                        <Col md={7} className="text-center">
                            <Image fluid alt={mp.name} src={mp.posterImageUrl}/>
                            <Container className="movie-poster-view__info-container my-3 px-4 py-2">
                                <Row>
                                    <Col>
                                        <StarRatingComponent name="Sample rating" value={mp.rating}/>
                                    </Col>
                                    <Col>
                                        <p className="movie-poster-view__info-text ">Total Ratings: {mp.ratingCount}</p>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <h3 className="movie-poster-view__info-header">Artist</h3>
                                        <p className="movie-poster-view__info-text">{mp.artist}</p>
                                    </Col>
                                    <Col>
                                        <h3 className="movie-poster-view__info-header">Year</h3>
                                        <p className="movie-poster-view__info-text">{mp.year}</p>
                                    </Col>
                                </Row>
                            </Container>
                        </Col>
                        <Col md={5}>
                            <h2 className="movie-poster-view__header">Reviews</h2>
                            <ReviewsList/>
                        </Col>
                    </Row>
                </Container>
            );
        default:
            return <Loading/>;
    }
}

export const MoviePosterView = connect(mapStateToProps, mapDispatchToProps)(DisconnectedMoviePosterView);