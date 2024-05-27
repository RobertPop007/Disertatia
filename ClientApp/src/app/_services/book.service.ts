import { Injectable } from "@angular/core";
import { Book } from "model/book";
import { environment } from "src/environments/environment";
import { BookParams } from "../_models/bookParams";
import { User } from "../_models/user";
import { UserParams } from "../_models/userParams";
import { AccountService } from "./account.service";
import { BooksService } from "api/books.service";
import { map, of, take } from "rxjs";
import { getPaginatedResult, getPaginationHeaders } from "./paginationHelper";
import { HttpClient } from "@angular/common/http";
import { ObjectId } from "model/objectId";

@Injectable({
    providedIn: 'root'
})

export class BookAngularService {

    baseUrl = environment.apiUrl;
    book!: Book;
    bookParams!: BookParams;
    user!: User;
    bookCache = new Map();
    userParams!: UserParams;
    searchedBook = "";

    constructor(private http: HttpClient, 
                private accountService: AccountService, 
                private bookService: BooksService) {
        this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
          this.user = user;
          this.bookParams = new BookParams(user, this.searchedBook);
        })
       }

    getBookParams(){
    return this.bookParams;
    }
    
    setBookParams(params: BookParams){
        this.bookParams = params;
      }
    
    resetBookParams(){
        this.searchedBook = "";
        this.bookParams = new BookParams(this.user, this.searchedBook);
        return this.bookParams;
    }

    getBook(bookParams: BookParams) {
      console.log("test")
        var response = this.bookCache.get(Object.values(bookParams).join('-'));
   
        if(response){
          return of(response);
        }
    
        let params = getPaginationHeaders(bookParams.pageNumber, bookParams.pageSize);
    
        params = params.append('searchedBook', bookParams.searchedBook);
        params = params.append('orderBy', bookParams.orderBy);
    
        return getPaginatedResult<Book[]>(this.baseUrl + 'Books/GetAllBooks', params, this.http).
          pipe(map(response => {
            this.bookCache.set(Object.values(bookParams).join('-'), response);
            return response;
          }))
    }

    addBook(bookId: ObjectId){
        return this.bookService.apiBooksAddBookToUserBookIdPost(bookId);
    }

    getBooksForUser(predicate: string, pageNumber: number, pageSize: number){
        let params = getPaginationHeaders(pageNumber, pageSize);

        params = params.append('predicate', predicate);

        return getPaginatedResult<Partial<Book[]>>(this.baseUrl + 'Books/GetBooksFor', params, this.http);
    }

    deleteBookForUser(bookId: ObjectId){
        return this.http.delete(this.baseUrl + 'Books/DeleteBookFromUser/' + bookId, {responseType: 'text'});
    }
}