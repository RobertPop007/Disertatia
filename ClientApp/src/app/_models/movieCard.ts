import { ObjectId } from "model/objectId";

export interface MovieCard{
    id: ObjectId;
    fullTitle: string;
    year: string;
    image: string;
    imDbRating: string;
    title: string;
}