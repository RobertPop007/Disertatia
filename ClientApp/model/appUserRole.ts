/**
 * Proiect_licenta
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { AppRole } from './appRole';
import { AppUser } from './appUser';


export interface AppUserRole { 
    userId?: number;
    roleId?: number;
    user?: AppUser;
    role?: AppRole;
}
