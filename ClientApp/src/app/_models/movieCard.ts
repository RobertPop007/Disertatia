import { ObjectId } from "model/objectId";

export interface MovieCard{
    id: ObjectId;
    originalTitle: string;
    releaseDate: string;
    posterPath: string;
    title: string;
    voteAverage: number;
}