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
 */import { AppUser } from './appUser';


export interface Review { 
    reviewId?: string;
    userId?: string;
    user?: AppUser;
    itemId?: string;
    shortDescription?: string;
    mainDescription?: string;
    stars?: number;
    reviewDate?: Date;
}