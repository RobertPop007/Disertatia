import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { BooksService } from "api/books.service";
import { Book } from "model/book";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class BookDetailedResolver implements Resolve<Book>{

    constructor(private bookService: BooksService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<Book>{
        return this.bookService.getBook(route.paramMap.get('title')!);
    }

}