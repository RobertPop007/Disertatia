/**
 * Proiect disertație
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { ObjectId } from './objectId';

export interface Book { 
    id?: ObjectId;
    book_id?: number;
    title?: string;
    authors?: string;
    average_rating?: number;
    isbn?: string;
    isbn13?: number;
    language_code?: string;
    num_pages?: number;
    ratings_count?: number;
    text_reviews_count?: number;
    publication_date?: string;
    publisher?: string;
    cover_url?: string;
    reviews_ids?: Array<string>;
}