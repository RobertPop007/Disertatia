import { Component, Input, OnInit } from '@angular/core';
import { BooksService } from 'api/books.service';
import { Book } from 'model/book';
import { ObjectId } from 'model/objectId';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { BookCard } from 'src/app/_models/bookCard';
import { BookAngularService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.scss']
})
export class BookCardComponent implements OnInit {

  @Input() book!: BookCard;
  res!: boolean;

  constructor(private bookAngularService: BookAngularService,
    private bookService: BooksService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.bookService.apiBooksBookAlreadyAddedGet(this.book.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addBook(book: Book){
    this.bookAngularService.addBook(book.id!).subscribe(() => {
      this.toastr.success("You have added " + book.title);
    })

    this.res = true;
  }

  deleteBook(book: Book){
    this.bookAngularService.deleteBookForUser(book.id!).subscribe(() => {
      this.toastr.success("You have deleted " + book.title);
    })

    this.res = false;
  }

  isBookAlreadyAdded(bookId: ObjectId): boolean{
    this.bookService.apiBooksBookAlreadyAddedGet(bookId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
