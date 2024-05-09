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

import { Book } from '../model/book';
import { ObjectId } from '../model/objectId';
import { ReviewDto } from '../model/reviewDto';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class BooksService {

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
     * @param book_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksAddBookToUserBookIdPost(book_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksAddBookToUserBookIdPost(book_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksAddBookToUserBookIdPost(book_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksAddBookToUserBookIdPost(book_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (book_id === null || book_id === undefined) {
            throw new Error('Required parameter book_id was null or undefined when calling apiBooksAddBookToUserBookIdPost.');
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Books/AddBookToUser/${encodeURIComponent(String(book_id))}`,
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
     * @param book_id 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksAddReviewForBookIdPost(book_id: ObjectId, body?: ReviewDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksAddReviewForBookIdPost(book_id: ObjectId, body?: ReviewDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksAddReviewForBookIdPost(book_id: ObjectId, body?: ReviewDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksAddReviewForBookIdPost(book_id: ObjectId, body?: ReviewDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (book_id === null || book_id === undefined) {
            throw new Error('Required parameter book_id was null or undefined when calling apiBooksAddReviewForBookIdPost.');
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

        return this.httpClient.request<any>('post',`${this.basePath}/api/Books/AddReviewFor/${encodeURIComponent(String(book_id))}`,
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
     * @param book_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksBookAlreadyAddedGet(book_id?: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<boolean>;
    public apiBooksBookAlreadyAddedGet(book_id?: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<boolean>>;
    public apiBooksBookAlreadyAddedGet(book_id?: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<boolean>>;
    public apiBooksBookAlreadyAddedGet(book_id?: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (book_id !== undefined && book_id !== null) {
            queryParameters = queryParameters.set('bookId', <any>book_id);
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

        return this.httpClient.request<boolean>('get',`${this.basePath}/api/Books/BookAlreadyAdded`,
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
     * @param book_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksDeleteBookFromUserBookIdDelete(book_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksDeleteBookFromUserBookIdDelete(book_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksDeleteBookFromUserBookIdDelete(book_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksDeleteBookFromUserBookIdDelete(book_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (book_id === null || book_id === undefined) {
            throw new Error('Required parameter book_id was null or undefined when calling apiBooksDeleteBookFromUserBookIdDelete.');
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

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Books/DeleteBookFromUser/${encodeURIComponent(String(book_id))}`,
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
     * @param book_id 
     * @param review_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksDeleteReviewForBookIdDelete(book_id: ObjectId, review_id?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksDeleteReviewForBookIdDelete(book_id: ObjectId, review_id?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksDeleteReviewForBookIdDelete(book_id: ObjectId, review_id?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksDeleteReviewForBookIdDelete(book_id: ObjectId, review_id?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (book_id === null || book_id === undefined) {
            throw new Error('Required parameter book_id was null or undefined when calling apiBooksDeleteReviewForBookIdDelete.');
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

        return this.httpClient.request<any>('delete',`${this.basePath}/api/Books/DeleteReviewFor/${encodeURIComponent(String(book_id))}`,
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
     * @param searched_book 
     * @param order_by 
     * @param page_number 
     * @param page_size 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksGetAllBooksGet(searched_book?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksGetAllBooksGet(searched_book?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksGetAllBooksGet(searched_book?: string, order_by?: string, page_number?: number, page_size?: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksGetAllBooksGet(searched_book?: string, order_by?: string, page_number?: number, page_size?: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {





        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (searched_book !== undefined && searched_book !== null) {
            queryParameters = queryParameters.set('SearchedBook', <any>searched_book);
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

        return this.httpClient.request<any>('get',`${this.basePath}/api/Books/GetAllBooks`,
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
    public apiBooksGetBooksForUsernameGet(username: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiBooksGetBooksForUsernameGet(username: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiBooksGetBooksForUsernameGet(username: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiBooksGetBooksForUsernameGet(username: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (username === null || username === undefined) {
            throw new Error('Required parameter username was null or undefined when calling apiBooksGetBooksForUsernameGet.');
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

        return this.httpClient.request<any>('get',`${this.basePath}/api/Books/GetBooksFor/${encodeURIComponent(String(username))}`,
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
     * @param book_id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiBooksGetReviewsForBookIdGet(book_id: ObjectId, observe?: 'body', reportProgress?: boolean): Observable<Array<ReviewDto>>;
    public apiBooksGetReviewsForBookIdGet(book_id: ObjectId, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<ReviewDto>>>;
    public apiBooksGetReviewsForBookIdGet(book_id: ObjectId, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<ReviewDto>>>;
    public apiBooksGetReviewsForBookIdGet(book_id: ObjectId, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (book_id === null || book_id === undefined) {
            throw new Error('Required parameter book_id was null or undefined when calling apiBooksGetReviewsForBookIdGet.');
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

        return this.httpClient.request<Array<ReviewDto>>('get',`${this.basePath}/api/Books/GetReviewsFor/${encodeURIComponent(String(book_id))}`,
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
     * @param name 
     * @param title 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getBook(name: string, title?: string, observe?: 'body', reportProgress?: boolean): Observable<Book>;
    public getBook(name: string, title?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Book>>;
    public getBook(name: string, title?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Book>>;
    public getBook(name: string, title?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (name === null || name === undefined) {
            throw new Error('Required parameter name was null or undefined when calling getBook.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (title !== undefined && title !== null) {
            queryParameters = queryParameters.set('title', <any>title);
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

        return this.httpClient.request<Book>('get',`${this.basePath}/api/Books/${encodeURIComponent(String(name))}`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
