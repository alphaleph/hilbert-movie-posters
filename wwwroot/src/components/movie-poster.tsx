import React from 'react';
// import { connect } from 'react-redux';
import { MoviePosterProps } from '../types/index';
// import { addMoviePoster } from '../redux/actions';
// import { getMoviePosterById } from '../redux/selectors'

// // Mapping State
// const mapStateToProps = (state, ownProps) => {
//     return {
//        moviePosters: getMoviePostersOnPage(state)
//     }
// }
// // Example
// const mapStateToProps = (state: AppState, ownProps: MoviePostersListViewProps) => {
//     return {
//         moviePosters: state.ui.mainMoviePostersList.map((mpId) => state.entities.moviePosters.byId[mpId]),
//         state: state.ui.mainMoviePostersList.state,
//     }
// }


// // Mapping Dispatch
// const mapDispatchToProps = {
//     addMoviePoster
// }
// which is shorthand for...
// const mapDispatchToProps = (dispatch, ownProps) => {
//     return {
        // addMoviePoster: (id) => {
        //     dispatch(addMoviePoster(id))
        // }
//     }
// }

// const handleAddMoviePoster = () => {
//     props.addMoviePoster(input);
//     setInput('');
// }

export const MoviePoster = (props: MoviePosterProps) => {
    return (
        <p>{props.moviePosterName} ({props.moviePosterYear})</p>
        // <button onClick={props.handleAddMoviePoster}> </button>
    );
}

// export const VisibleMoviePoster = connect(mapStateToProps, mapDispatchToProps)(MoviePoster);
