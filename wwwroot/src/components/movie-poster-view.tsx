import React, { useState } from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePosterViewProps } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { requestGetMoviePosters, requestGetMoviePoster } from '../redux/actions';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import { Breadcrumb } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { Loading } from './loading';
import { Error } from './error';
import { MoviePosterInfo } from './movie-poster-info';
import { ReviewsList } from './reviews-list';
import { DeleteModal } from './delete-modal';
import '../styles/components/movie-poster-view.scss';

const mapStateToProps = (state: AppState) => {
    return {
        availableMoviePosters: state.ui.mainMoviePostersList.moviePosters,
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters,
    requestGetMoviePoster
}

export const DisconnectedMoviePosterView: React.FunctionComponent<MoviePosterViewProps> = (props: MoviePosterViewProps) => {
    const [isShowDelete, setIsShowDelete] = useState(false);

    const showDeleteModal = () => setIsShowDelete(true);
    const hideDeleteModal = () => setIsShowDelete(false);

    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    }

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error history={props.history}/>;
        case UI_LOADED:
            if (!props.availableMoviePosters.includes(parseInt(props.match.params.id))) {
                props.requestGetMoviePoster(parseInt(props.match.params.id));
                return <Loading/>;
            }
            const mp: IMoviePosterData | undefined = props.moviePostersList.find(mp => mp.moviePosterId === parseInt(props.match.params.id, 10));
            if (mp === undefined) {
                return <Error history={props.history}/>;
            }

            return (
                <Container className="movie-poster-view__container my-2">
                    <Breadcrumb className="pt-2 movie-poster-view__breadcrumb">
                        <LinkContainer to="/browse/movie-posters">
                            <Breadcrumb.Item>Browse Movie Posters</Breadcrumb.Item>
                        </LinkContainer>
                        <Breadcrumb.Item active>{mp.name}</Breadcrumb.Item>
                    </Breadcrumb>
                    <h1 className="movie-poster-view__header mt-2 mb-5">{mp.name}</h1>
                    <Row>
                        <Col md={7} className="text-center">
                            <Image fluid alt={mp.name} src={mp.posterImageUrl}/>
                            <MoviePosterInfo rating={mp.rating} ratingCount={mp.ratingCount} artist={mp.artist} year={mp.year}/>
                            <Button variant="outline-danger" onClick={showDeleteModal}>Delete Movie Poster</Button>
                        </Col>
                        <Col md={5}>
                            <h2 className="movie-poster-view__header">Reviews</h2>
                            <ReviewsList/>
                        </Col>
                    </Row>
                    <DeleteModal show={isShowDelete} onHide={hideDeleteModal}/>
                </Container>
            );
        default:
            return <Loading/>;
    }
}

export const MoviePosterView = connect(mapStateToProps, mapDispatchToProps)(DisconnectedMoviePosterView);