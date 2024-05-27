import { Images } from "model/images";
import { ObjectId } from "model/objectId";

export interface AnimeCard{
    id: ObjectId;
    Mal_id: number;
    fullTitle: string;
    year: number;
    images?: Images;
    score: number;
    title: string;
    popularity: number;
}