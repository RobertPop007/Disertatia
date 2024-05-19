import { ObjectId } from "model/objectId";

export interface TvShowCard{
    tv_show_id: ObjectId;
    fullTitle: string;
    year: string;
    image: string;
    imDbRating: string;
}