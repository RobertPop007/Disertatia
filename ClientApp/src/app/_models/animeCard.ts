import { ObjectId } from "model/objectId";

export interface AnimeCard{
    id: ObjectId;
    Mal_id: number;
    fullTitle: string;
    year: number;
    image: string;
    score: number;
    title: string;
    popularity: number;
}