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
import { BelongsToCollection } from './belongsToCollection';
import { Credits } from './credits';
import { MovieGenre } from './movieGenre';
import { MovieImages } from './movieImages';
import { ObjectId } from './objectId';
import { ProductionCompany } from './productionCompany';
import { ProductionCountry } from './productionCountry';
import { Similar } from './similar';
import { SpokenLanguage } from './spokenLanguage';
import { Videos } from './videos';

export interface Movie { 
    movieId?: ObjectId;
    backdropPath?: string;
    belongsToCollection?: BelongsToCollection;
    budget?: number;
    genres?: Array<MovieGenre>;
    homepage?: string;
    id?: number;
    imdbId?: string;
    originCountry?: Array<string>;
    originalLanguage?: string;
    originalTitle?: string;
    overview?: string;
    popularity?: number;
    posterPath?: string;
    productionCompanies?: Array<ProductionCompany>;
    productionCountries?: Array<ProductionCountry>;
    releaseDate?: string;
    revenue?: number;
    runtime?: number;
    spokenLanguages?: Array<SpokenLanguage>;
    status?: string;
    tagline?: string;
    title?: string;
    voteAverage?: number;
    voteCount?: number;
    videos?: Videos;
    similar?: Similar;
    images?: MovieImages;
    credits?: Credits;
    reviewsIds?: Array<string>;
}