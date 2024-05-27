import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Book } from 'model/book';
import { ToastrService } from 'ngx-toastr';
import { BookAngularService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-book-card-added',
  templateUrl: './book-card-added.component.html',
  styleUrls: ['./book-card-added.component.scss']
})
export class BookCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() book!: Book;
  bookAlreadyAdded!: boolean;
  
  constructor(private bookAngularService: BookAngularService,
    private toastr: ToastrService) {
      
     }

  ngOnInit(): void {
  }

  deleteBookForUser(book: Book){
    this.bookAngularService.deleteBookForUser(book.id!).subscribe(() => {
      this.toastr.success("You have deleted " + book.title);

      this.deleteEvent.emit("This value is coming from child");
    });
  }
}
