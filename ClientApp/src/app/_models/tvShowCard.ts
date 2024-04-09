import { ObjectId } from "model/objectId";

export interface TvShowCard{
    id: ObjectId;
    fullTitle: string;
    year: string;
    image: string;
    imDbRating: string;
}