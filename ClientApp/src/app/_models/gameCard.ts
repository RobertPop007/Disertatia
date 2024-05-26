import { ObjectId } from "model/objectId";

export interface GameCard{
    id: ObjectId;
    name: string;
    released: string;
    rating: number;
    backgroundImage: string;
}