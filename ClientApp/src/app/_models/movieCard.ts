import { ObjectId } from "model/objectId";

export interface MovieCard{
    movie_id: ObjectId;
    fullTitle: string;
    year: string;
    image: string;
    imDbRating: string;
    title: string;
}