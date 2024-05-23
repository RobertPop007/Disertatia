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

import { DatumManga } from '../model/datumManga';
import { ObjectId } from '../model/objectId';
import { ReviewDto } from '../model/reviewDto';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class MangaService {

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
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaAddMangaToUserMangaIdPost(mangaId: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaAddMangaToUserMangaIdPost(mangaId: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaAddMangaToUserMangaIdPost(mangaId: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaAddMangaToUserMangaIdPost(mangaId: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (mangaId === null || mangaId === undefined) {
            throw new Error('Required parameter mangaId was null or undefined when calling apiMangaAddMangaToUserMangaIdPost.');
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Manga/AddMangaToUser/${encodeURIComponent(String(mangaId))}`,
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
     * @param mangaId 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaAddReviewForMangaIdPost(mangaId: ObjectId, body?: ReviewDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaAddReviewForMangaIdPost(mangaId: ObjectId, body?: ReviewDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaAddReviewForMangaIdPost(mangaId: ObjectId, body?: ReviewDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaAddReviewForMangaIdPost(mangaId: ObjectId, body?: ReviewDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (mangaId === null || mangaId === undefined) {
            throw new Error('Required parameter mangaId was null or undefined when calling apiMangaAddReviewForMangaIdPost.');
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Manga/AddReviewFor/${encodeURIComponent(String(mangaId))}`,
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
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaDeleteMangaFromUserMangaIdDelete(mangaId: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaDeleteMangaFromUserMangaIdDelete(mangaId: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaDeleteMangaFromUserMangaIdDelete(mangaId: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaDeleteMangaFromUserMangaIdDelete(mangaId: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (mangaId === null || mangaId === undefined) {
            throw new Error('Required parameter mangaId was null or undefined when calling apiMangaDeleteMangaFromUserMangaIdDelete.');
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

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Manga/DeleteMangaFromUser/${encodeURIComponent(String(mangaId))}`,
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
     * @param mangaId 
     * @param reviewId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaDeleteReviewForMangaIdDelete(mangaId: ObjectId, reviewId?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaDeleteReviewForMangaIdDelete(mangaId: ObjectId, reviewId?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaDeleteReviewForMangaIdDelete(mangaId: ObjectId, reviewId?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaDeleteReviewForMangaIdDelete(mangaId: ObjectId, reviewId?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (mangaId === null || mangaId === undefined) {
            throw new Error('Required parameter mangaId was null or undefined when calling apiMangaDeleteReviewForMangaIdDelete.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (reviewId !== undefined && reviewId !== null) {
            queryParameters = queryParameters.set('reviewId', <any>reviewId);
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

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Manga/DeleteReviewFor/${encodeURIComponent(String(mangaId))}`,
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
     * @param reviewId 
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaDislikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaDislikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaDislikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaDislikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (reviewId === null || reviewId === undefined) {
            throw new Error('Required parameter reviewId was null or undefined when calling apiMangaDislikeReviewForReviewIdPost.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (mangaId !== undefined && mangaId !== null) {
            queryParameters = queryParameters.set('mangaId', <any>mangaId);
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Manga/DislikeReviewFor/${encodeURIComponent(String(reviewId))}`,
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
     * @param searchedManga 
     * @param orderBy 
     * @param pageNumber 
     * @param pageSize 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaGetAllMangasGet(searchedManga?: string, orderBy?: string, pageNumber?: number, pageSize?: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaGetAllMangasGet(searchedManga?: string, orderBy?: string, pageNumber?: number, pageSize?: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaGetAllMangasGet(searchedManga?: string, orderBy?: string, pageNumber?: number, pageSize?: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaGetAllMangasGet(searchedManga?: string, orderBy?: string, pageNumber?: number, pageSize?: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {





        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (searchedManga !== undefined && searchedManga !== null) {
            queryParameters = queryParameters.set('SearchedManga', <any>searchedManga);
        }
        if (orderBy !== undefined && orderBy !== null) {
            queryParameters = queryParameters.set('OrderBy', <any>orderBy);
        }
        if (pageNumber !== undefined && pageNumber !== null) {
            queryParameters = queryParameters.set('PageNumber', <any>pageNumber);
        }
        if (pageSize !== undefined && pageSize !== null) {
            queryParameters = queryParameters.set('PageSize', <any>pageSize);
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

        return this.httpClient.request<any>('get',`${this.basePath}/api/Manga/GetAllMangas`,
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
    public apiMangaGetMangasForUsernameGet(username: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaGetMangasForUsernameGet(username: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaGetMangasForUsernameGet(username: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaGetMangasForUsernameGet(username: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (username === null || username === undefined) {
            throw new Error('Required parameter username was null or undefined when calling apiMangaGetMangasForUsernameGet.');
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

        return this.httpClient.request<any>('get',`${this.basePath}/api/Manga/GetMangasFor/${encodeURIComponent(String(username))}`,
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
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaGetReviewsForMangaIdGet(mangaId: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<Array<ReviewDto>>;
    public apiMangaGetReviewsForMangaIdGet(mangaId: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ReviewDto>>>;
    public apiMangaGetReviewsForMangaIdGet(mangaId: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ReviewDto>>>;
    public apiMangaGetReviewsForMangaIdGet(mangaId: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (mangaId === null || mangaId === undefined) {
            throw new Error('Required parameter mangaId was null or undefined when calling apiMangaGetReviewsForMangaIdGet.');
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

        return this.httpClient.request<Array<ReviewDto>>('get',`${this.basePath}/api/Manga/GetReviewsFor/${encodeURIComponent(String(mangaId))}`,
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
     * @param reviewId 
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaLikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiMangaLikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiMangaLikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiMangaLikeReviewForReviewIdPost(reviewId: string, mangaId?: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (reviewId === null || reviewId === undefined) {
            throw new Error('Required parameter reviewId was null or undefined when calling apiMangaLikeReviewForReviewIdPost.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (mangaId !== undefined && mangaId !== null) {
            queryParameters = queryParameters.set('mangaId', <any>mangaId);
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Manga/LikeReviewFor/${encodeURIComponent(String(reviewId))}`,
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
     * @param mangaId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiMangaMangaAlreadyAddedGet(mangaId?: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<boolean>;
    public apiMangaMangaAlreadyAddedGet(mangaId?: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<boolean>>;
    public apiMangaMangaAlreadyAddedGet(mangaId?: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<boolean>>;
    public apiMangaMangaAlreadyAddedGet(mangaId?: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (mangaId !== undefined && mangaId !== null) {
            queryParameters = queryParameters.set('mangaId', <any>mangaId);
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

        return this.httpClient.request<boolean>('get',`${this.basePath}/api/Manga/MangaAlreadyAdded`,
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
     * @param title 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getManga(title: string, observe?: 'body', reportProgress?: boolean): Observable<DatumManga>;
    public getManga(title: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<DatumManga>>;
    public getManga(title: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<DatumManga>>;
    public getManga(title: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (title === null || title === undefined) {
            throw new Error('Required parameter title was null or undefined when calling getManga.');
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

        return this.httpClient.request<DatumManga>('get',`${this.basePath}/api/Manga/${encodeURIComponent(String(title))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
