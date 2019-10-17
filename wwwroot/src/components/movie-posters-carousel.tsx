import React from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePostersCarouselProps } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import { requestGetMoviePosters } from '../redux/actions';
import { ListEmpty } from './list-empty';
import { Error } from './error';
import { Loading } from './loading';
import Carousel from 'react-bootstrap/Carousel';
import '../styles/components/movie-posters-carousel';

const CAROUSEL_BUFFER_SIZE: number = 10;

const mapStateToProps = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const DisconnectedMoviePostersCarousel: React.FunctionComponent<MoviePostersCarouselProps> = (props: MoviePostersCarouselProps) => {
    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    } 

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error history={props.history}/>;
        case UI_LOADED:
            if (props.moviePostersList.length === 0) {
                return <ListEmpty/>;
            }
            const moviePostersBuffer = (props.moviePostersList.length > CAROUSEL_BUFFER_SIZE )
                                            ? props.moviePostersList.slice(0, CAROUSEL_BUFFER_SIZE) 
                                            : props.moviePostersList;
            const carouselItems = moviePostersBuffer.map((mp: IMoviePosterData) => 
                <Carousel.Item key={mp.moviePosterId}>
                    <img className="movie-posters-carousel__image" alt={mp.name} src={mp.posterImageUrl}/>
                    <Carousel.Caption>
                        <h3>
                            {`${mp.name} (${mp.year})`}
                        </h3>
                    </Carousel.Caption>
                </Carousel.Item>
            );
            return (
                <Carousel nextLabel="Next movie poster" prevLabel="Previous movie poster" className="movie-posters-carousel__main">
                    {carouselItems}
                </Carousel>
            );
        default:
            return <Loading/>
    }
}

export const MoviePostersCarousel = connect(mapStateToProps, mapDispatchToProps)(DisconnectedMoviePostersCarousel as unknown as any);
