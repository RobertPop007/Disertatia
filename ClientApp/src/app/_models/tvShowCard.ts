import { ObjectId } from "model/objectId";

export interface TvShowCard{
    id: ObjectId;
    originalName: string;
    name: string;
    firstAirDate: string;
    posterPath: string;
    voteAverage: number;
}