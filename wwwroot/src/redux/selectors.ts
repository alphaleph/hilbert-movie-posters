import { createSelector } from 'reselect';
import { AppState, MoviePostersDict } from '../types/index';

export const selectMoviePostersEntity = (state: AppState): MoviePostersDict => state.entities.moviePosters.byId;
export const selectMainMoviePostersListIds = (state: AppState): number[] => state.ui.mainMoviePostersList.moviePosters;

export const selectMoviePosters = createSelector(
    [selectMoviePostersEntity, selectMainMoviePostersListIds],
    (moviePostersEntity, mainMoviePostersListIds) => {
        return mainMoviePostersListIds.map(id => moviePostersEntity[id])
    }
);

// Example: 
// const getMoviePosters = state => state.entities.moviePosters.AllIds;
// const getCurrentPage = state => state.currentPage;
// const getPageSize = state => state.pageSize;

// const getMoviePostersOnPage = createSelector(
//     [ getMoviePosters, getCurrentPage, getPageSize ],
//     (moviePosters, currentPage, pageSize) => {
//         moviePosters.slice(currentPage * pageSize, (currentPage+1) * pageSize - 1)
//     }
// );

// Example:
// const getVisibilityFilter = (state, props) => state.todoLists[props.listId].visibilityFilter;
// const getTodos = (state, props) => state.todoLists[props.listId].todos;

// export const getVisibleTodos = createSelector(
//     [ getVisibilityFilter, getTodos ],
//     (visibilityFilter, todos) => {
//         switch (visibilityFilter) {
//             case SHOW_ALL:
//                 return todos;
//             case SHOW_COMPLETED:
//                 return todos.filter(t => t.completed);
//             case SHOW_ACTIVE:
//                 return todos.filter(t => !t.completed);
                // default:
                //     return todos;
//         }
//     }
// );

//Example: Multiple instances of component
// const makeUniqueSelectorInstance = () => createSelector(
//     [selectItems, selectItemId],
//     (items, itemId) => items[itemId]
// );

// FOR A UNIQUE-IFIED SELECTOR State Mappers
// const makeMapState = (state) => {
//     const selectItemForThisComponent = makeUniqueSelectorInstance();

//     return function realMapState(state, ownProps) {
//         const item = selectItemForThisComponent(state, ownProps.itemId);

//         return {item};
//     }
// };

// export default connect(makeMapState)(SomeComponent);