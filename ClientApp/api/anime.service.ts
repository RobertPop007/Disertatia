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
 *//* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs';

import { Datum } from '../model/datum';
import { ObjectId } from '../model/objectId';
import { ReviewDto } from '../model/reviewDto';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class AnimeService {

    protected basePath = 'https://localhost:5001';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * 
     * 
     * @param anime_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeAddAnimeToUserAnimeIdPost(anime_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeAddAnimeToUserAnimeIdPost(anime_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeAddAnimeToUserAnimeIdPost(anime_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeAddAnimeToUserAnimeIdPost(anime_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (anime_id === null || anime_id === undefined) {
            throw new Error('Required parameter anime_id was null or undefined when calling apiAnimeAddAnimeToUserAnimeIdPost.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('post',`${this.basePath}/api/Anime/AddAnimeToUser/${encodeURIComponent(String(anime_id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param anime_id 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeAddReviewForAnimeIdPost(anime_id: ObjectId, body?: ReviewDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeAddReviewForAnimeIdPost(anime_id: ObjectId, body?: ReviewDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeAddReviewForAnimeIdPost(anime_id: ObjectId, body?: ReviewDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeAddReviewForAnimeIdPost(anime_id: ObjectId, body?: ReviewDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (anime_id === null || anime_id === undefined) {
            throw new Error('Required parameter anime_id was null or undefined when calling apiAnimeAddReviewForAnimeIdPost.');
        }


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('post',`${this.basePath}/api/Anime/AddReviewFor/${encodeURIComponent(String(anime_id))}`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param anime_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeAnimeAlreadyAddedGet(anime_id?: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<boolean>;
    public apiAnimeAnimeAlreadyAddedGet(anime_id?: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<boolean>>;
    public apiAnimeAnimeAlreadyAddedGet(anime_id?: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<boolean>>;
    public apiAnimeAnimeAlreadyAddedGet(anime_id?: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (anime_id !== undefined && anime_id !== null) {
            queryParameters = queryParameters.set('animeId', <any>anime_id);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<boolean>('get',`${this.basePath}/api/Anime/AnimeAlreadyAdded`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param anime_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeDeleteAnimeFromUserAnimeIdDelete(anime_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeDeleteAnimeFromUserAnimeIdDelete(anime_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeDeleteAnimeFromUserAnimeIdDelete(anime_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeDeleteAnimeFromUserAnimeIdDelete(anime_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (anime_id === null || anime_id === undefined) {
            throw new Error('Required parameter anime_id was null or undefined when calling apiAnimeDeleteAnimeFromUserAnimeIdDelete.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Anime/DeleteAnimeFromUser/${encodeURIComponent(String(anime_id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param anime_id 
     * @param review_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeDeleteReviewForAnimeIdDelete(anime_id: ObjectId, review_id?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeDeleteReviewForAnimeIdDelete(anime_id: ObjectId, review_id?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeDeleteReviewForAnimeIdDelete(anime_id: ObjectId, review_id?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeDeleteReviewForAnimeIdDelete(anime_id: ObjectId, review_id?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (anime_id === null || anime_id === undefined) {
            throw new Error('Required parameter anime_id was null or undefined when calling apiAnimeDeleteReviewForAnimeIdDelete.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (review_id !== undefined && review_id !== null) {
            queryParameters = queryParameters.set('reviewId', <any>review_id);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Anime/DeleteReviewFor/${encodeURIComponent(String(anime_id))}`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param searched_anime 
     * @param order_by 
     * @param page_number 
     * @param page_size 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeGetAllAnimesGet(searched_anime?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeGetAllAnimesGet(searched_anime?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeGetAllAnimesGet(searched_anime?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeGetAllAnimesGet(searched_anime?: string, order_by?: string, page_number?: number, page_size?: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {





        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (searched_anime !== undefined && searched_anime !== null) {
            queryParameters = queryParameters.set('SearchedAnime', <any>searched_anime);
        }
        if (order_by !== undefined && order_by !== null) {
            queryParameters = queryParameters.set('OrderBy', <any>order_by);
        }
        if (page_number !== undefined && page_number !== null) {
            queryParameters = queryParameters.set('PageNumber', <any>page_number);
        }
        if (page_size !== undefined && page_size !== null) {
            queryParameters = queryParameters.set('PageSize', <any>page_size);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/Anime/GetAllAnimes`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param username 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeGetAnimesForUsernameGet(username: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiAnimeGetAnimesForUsernameGet(username: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiAnimeGetAnimesForUsernameGet(username: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiAnimeGetAnimesForUsernameGet(username: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (username === null || username === undefined) {
            throw new Error('Required parameter username was null or undefined when calling apiAnimeGetAnimesForUsernameGet.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/Anime/GetAnimesFor/${encodeURIComponent(String(username))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param anime_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiAnimeGetReviewsForAnimeIdGet(anime_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<Array<ReviewDto>>;
    public apiAnimeGetReviewsForAnimeIdGet(anime_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ReviewDto>>>;
    public apiAnimeGetReviewsForAnimeIdGet(anime_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ReviewDto>>>;
    public apiAnimeGetReviewsForAnimeIdGet(anime_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (anime_id === null || anime_id === undefined) {
            throw new Error('Required parameter anime_id was null or undefined when calling apiAnimeGetReviewsForAnimeIdGet.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<ReviewDto>>('get',`${this.basePath}/api/Anime/GetReviewsFor/${encodeURIComponent(String(anime_id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param title 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getAnime(title: string, observe?: 'body', reportProgress?: boolean): Observable<Datum>;
    public getAnime(title: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Datum>>;
    public getAnime(title: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Datum>>;
    public getAnime(title: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (title === null || title === undefined) {
            throw new Error('Required parameter title was null or undefined when calling getAnime.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Datum>('get',`${this.basePath}/api/Anime/${encodeURIComponent(String(title))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
