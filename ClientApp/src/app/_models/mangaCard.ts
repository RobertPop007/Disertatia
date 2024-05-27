import { ObjectId } from "model/objectId";

export interface MangaCard{
    id: ObjectId;
    fullTitle: string;
    year: number;
    image: string;
    score: number;
    title: string;
    popularity: number;
}