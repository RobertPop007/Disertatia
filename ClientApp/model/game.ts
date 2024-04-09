/**
 * Proiect_licenta
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { AddedByStatusGame } from './addedByStatusGame';
import { DeveloperGame } from './developerGame';
import { EsrbRatingGame } from './esrbRatingGame';
import { GenreGame } from './genreGame';
import { ObjectId } from './objectId';
import { ParentPlatformGame } from './parentPlatformGame';
import { PlatformsGame } from './platformsGame';
import { PublisherGame } from './publisherGame';
import { RatingGame } from './ratingGame';
import { StoresGame } from './storesGame';
import { TagGame } from './tagGame';

export interface Game { 
    id?: ObjectId;
    gameId?: number;
    slug?: string;
    name?: string;
    nameOriginal?: string;
    description?: string;
    metacritic?: number;
    released?: string;
    tba?: boolean;
    updated?: Date;
    backgroundImage?: string;
    backgroundImageAdditional?: string;
    website?: string;
    rating?: number;
    ratingTop?: number;
    ratings?: Array<RatingGame>;
    added?: number;
    addedByStatus?: AddedByStatusGame;
    playtime?: number;
    screenshotsCount?: number;
    moviesCount?: number;
    creatorsCount?: number;
    achievementsCount?: number;
    parentAchievementsCount?: number;
    redditUrl?: string;
    redditName?: string;
    redditDescription?: string;
    redditLogo?: string;
    redditCount?: number;
    twitchCount?: number;
    youtubeCount?: number;
    reviewsTextCount?: number;
    ratingsCount?: number;
    suggestionsCount?: number;
    metacriticUrl?: string;
    parentsCount?: number;
    additionsCount?: number;
    gameSeriesCount?: number;
    reviewsCount?: number;
    saturatedColor?: string;
    dominantColor?: string;
    parentPlatforms?: Array<ParentPlatformGame>;
    platforms?: Array<PlatformsGame>;
    stores?: Array<StoresGame>;
    developers?: Array<DeveloperGame>;
    genres?: Array<GenreGame>;
    tags?: Array<TagGame>;
    publishers?: Array<PublisherGame>;
    esrbRating?: EsrbRatingGame;
    descriptionRaw?: string;
}