import { ObjectId } from "model/objectId";

export interface MovieCard{
    movieId: number;
    originalTitle: string;
    releaseDate: string;
    posterPath: string;
    title: string;
    voteAverage: number;
}