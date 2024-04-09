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
import { AuthorManga } from './authorManga';
import { DemographicManga } from './demographicManga';
import { GenreManga } from './genreManga';
import { ImagesManga } from './imagesManga';
import { ObjectId } from './objectId';
import { PublishedManga } from './publishedManga';
import { SerializationManga } from './serializationManga';
import { ThemeManga } from './themeManga';

export interface DatumManga { 
    id?: ObjectId;
    malId?: number;
    url?: string;
    images?: ImagesManga;
    title?: string;
    titleEnglish?: string;
    titleJapanese?: string;
    type?: string;
    chapters?: number;
    volumes?: number;
    status?: string;
    publishing?: boolean;
    published?: PublishedManga;
    score?: number;
    scored?: number;
    scoredBy?: number;
    rank?: number;
    popularity?: number;
    members?: number;
    favorites?: number;
    synopsis?: string;
    background?: string;
    authors?: Array<AuthorManga>;
    serializations?: Array<SerializationManga>;
    genres?: Array<GenreManga>;
    themes?: Array<ThemeManga>;
    demographics?: Array<DemographicManga>;
}