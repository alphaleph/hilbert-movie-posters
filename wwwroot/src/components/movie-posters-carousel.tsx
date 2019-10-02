import React from 'react';
import { connect } from 'react-redux';
import { AppState, MoviePostersCarouselProps } from '../types/index';
import { IMoviePosterData } from '../types/api_models';
import { UI_INIT, UI_LOADING, UI_LOADED, UI_ERROR } from '../redux/constants';
import { selectMoviePosters } from '../redux/selectors';
import { requestGetMoviePosters } from '../redux/actions';
import { ListEmpty } from './list-empty';
import { Error } from './error';
import { Whoops } from './whoops';
import { Loading } from './loading';
import Carousel from 'react-bootstrap/Carousel';
import '../styles/components/movie-posters-carousel';

const mapStateToProps  = (state: AppState) => {
    return {
        moviePostersList: selectMoviePosters(state),
        listState: state.ui.mainMoviePostersList.state
    }
}

const mapDispatchToProps = {
    requestGetMoviePosters
}

export const MoviePostersCarousel: React.FunctionComponent<MoviePostersCarouselProps> = (props: MoviePostersCarouselProps) => {
    if (props.listState === UI_INIT) {
        props.requestGetMoviePosters();
    } 

    switch (props.listState) {
        case UI_INIT || UI_LOADING:
            return <Loading/>;
        case UI_ERROR:
            return <Error/>
        case UI_LOADED:
            if (props.moviePostersList.length === 0) {
                return <ListEmpty/>;
            }
            const carouselItems = props.moviePostersList.map((mp: IMoviePosterData) => 
                <Carousel.Item key={mp.moviePosterId}>
                    <img className="movie-posters-carousel--image" alt={mp.name} src={mp.posterImageUrl}/>
                    <Carousel.Caption>
                        <h3>
                            {`${mp.name} (${mp.year})`}
                        </h3>
                    </Carousel.Caption>
                </Carousel.Item>
            );
            return (
                <Carousel nextLabel="Next movie poster" prevLabel="Previous movie poster" className="movie-posters-carousel--main">
                    {carouselItems}
                </Carousel>
            );
        default:
            return <Whoops/>
    }
}

export const ConnectedMoviePostersCarousel = connect(mapStateToProps, mapDispatchToProps)(MoviePostersCarousel as unknown as any);
