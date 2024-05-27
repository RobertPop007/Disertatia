import { Component, OnInit } from '@angular/core';
import { BooksService } from 'api/books.service';
import { BookCard } from 'src/app/_models/bookCard';
import { BookParams } from 'src/app/_models/bookParams';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { BookAngularService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css'],
  providers: [BookAngularService, BooksService]
})
export class BooksListComponent implements OnInit {

  books!: BookCard[];
  pagination!: Pagination;
  bookParams!: BookParams;
  user!: User;
  p?: string | number | undefined = 1;
  searcheBook = "";

  constructor(private bookAngularService: BookAngularService) {
    this.bookParams = this.bookAngularService.getBookParams();
   }

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(){
    this.bookAngularService.setBookParams(this.bookParams);

    this.bookAngularService.getBook(this.bookParams).subscribe(response => {
      this.books = response.result!;
      console.log(this.books)
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.bookParams = this.bookAngularService.resetBookParams();
    this.loadBooks();
  }

  pageChanged(event: any){
    this.bookParams.pageNumber = event.page;
    this.bookAngularService.setBookParams(this.bookParams);
    this.loadBooks();
  }
}
