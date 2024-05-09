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
import { AppUserAnimeItem } from './appUserAnimeItem';
import { AppUserBookItem } from './appUserBookItem';
import { AppUserGameItem } from './appUserGameItem';
import { AppUserMangaItem } from './appUserMangaItem';
import { AppUserMovieItem } from './appUserMovieItem';
import { AppUserRole } from './appUserRole';
import { AppUserTvShowItem } from './appUserTvShowItem';
import { Friendships } from './friendships';
import { Message } from './message';
import { Photo } from './photo';
import { Review } from './review';

export interface AppUser { 
    id?: string;
    user_name?: string;
    normalized_user_name?: string;
    email?: string;
    normalized_email?: string;
    email_confirmed?: boolean;
    password_hash?: string;
    security_stamp?: string;
    concurrency_stamp?: string;
    phone_number?: string;
    phone_number_confirmed?: boolean;
    two_factor_enabled?: boolean;
    lockout_end?: Date;
    lockout_enabled?: boolean;
    access_failed_count?: number;
    date_of_birth?: Date;
    known_as?: string;
    created?: Date;
    last_active?: Date;
    gender?: string;
    introduction?: string;
    interests?: string;
    city?: string;
    country?: string;
    photos?: Photo;
    friend_requests?: Array<string>;
    friends?: Array<Friendships>;
    messages_sent?: Array<Message>;
    messages_received?: Array<Message>;
    user_roles?: Array<AppUserRole>;
    app_user_movie?: Array<AppUserMovieItem>;
    app_user_tv_show?: Array<AppUserTvShowItem>;
    app_user_anime?: Array<AppUserAnimeItem>;
    app_user_manga?: Array<AppUserMangaItem>;
    app_user_game?: Array<AppUserGameItem>;
    app_user_book?: Array<AppUserBookItem>;
    is_subscribed_to_newsletter?: boolean;
    has_dark_mode?: boolean;
    reviews?: Array<Review>;
}