import { ObjectId } from "model/objectId";

export interface GameCard{
    id: ObjectId;
    name: string;
    year: string;
    released: string;
    rating: number;
    background_image: string;
    background_image_additional: string;
}