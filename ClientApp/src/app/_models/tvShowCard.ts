import { ObjectId } from "model/objectId";

export interface TvShowCard{
    tvShowId: ObjectId;
    fullTitle: string;
    year: string;
    image: string;
    imDbRating: string;
}