import { IMoviePosterData } from './IMoviePosterData';

export interface IPosterImageData {
    posterImageId: number;
    image: Int8Array;
    moviePosterId: number;
    moviePoster: IMoviePosterData;
}