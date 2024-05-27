import { ObjectId } from "model/objectId";

export interface BookCard{
    id: ObjectId;
    title: string;
    authors: string;
    averageRating: number;
    ratingCount: number;
    textReviewsCount: number;
    publicationDate: string;
    publisher: string;
    coverUrl: string;
}