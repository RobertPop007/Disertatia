import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from 'api/books.service';
import { UsersService } from 'api/users.service';
import { Book } from 'model/book';
import { MemberDto } from 'model/memberDto';
import { Review } from 'model/review';
import { ReviewDto } from 'model/reviewDto';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { BookDetailedResolver } from 'src/app/_resolvers/book-detailed.resolver';
import { AccountService } from 'src/app/_services/account.service';
import { BookAngularService } from 'src/app/_services/book.service';
import { StarRatingComponent } from 'src/app/helpers/star-rating/star-rating.component';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.scss'],
  providers: [
    BookDetailedResolver,
    BooksService,
    BookAngularService,
    UsersService
  ]
})
export class BookDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  @ViewChild('starRating') starRating!: StarRatingComponent;
  
  images : any;

  sanit!: DomSanitizer;
  book!: Book;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;
  userReview!: MemberDto;
  reviews!: Review[];
  reviewDto: ReviewDto = {
    shortDescription: '',
    mainDescription: '',
    stars: 0,
    score: 0
  };
  shortDescription: string = '';
  mainDescription: string = '';
  stars: number = 0;
  myForm!: FormGroup;
  
  constructor(private bookService: BooksService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private bookAngularService: BookAngularService,
    private userService: UsersService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer,
    private fb: FormBuilder) {
      this.sanit = sanitizer;
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
     }

  ngOnInit(): void {
    this.myForm = this.fb.group({
      Short_description: ['', Validators.required],
      Main_description: ['', [Validators.required]],
      stars: ['', Validators.required]
    });

    this.route.data.subscribe(data => {
      this.book = data['book'];
      console.log(data)
      
      // this.book.actorList = this.book.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.book.actorList?.map((n) => n.image);
      this.getReviews();
      this.bookService.apiBooksBookAlreadyAddedGet(this.book.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteBook(book: Book){
    this.bookAngularService.deleteBookForUser(book.id!).subscribe(() => {
      this.toastr.success("You have deleted " + book.title);
    })

    this.res = false;
  };

  loadBook(){
    this.bookService.getBook(this.route.snapshot.paramMap.get('title')!).subscribe(book => {
      this.book = book;
    })
  }

  addBook(book: Book){
    this.bookAngularService.addBook(book.id!).subscribe(() => {
      this.toastr.success("You have added " + book.title);
    })

    this.res = true;
  }

  toggleVideo() {
    this.videoplayer.nativeElement.play();
  }

  cleanURL(oldURL: string): SafeResourceUrl {
    return this.sanit.bypassSecurityTrustResourceUrl(oldURL);
  }

  getReviews(){
    this.bookService.apiBooksGetReviewsForBookIdGet(this.book.id!).subscribe(reviews => {
      this.reviews = reviews;
    }) 
  }

  getUserFromReview(username: string): MemberDto{
    this.userService.getUser(username).subscribe(user => {
      this.userReview = user;
    })
    return this.userReview;
  }

  generateArray(length: number): any[] {
    return Array.from({ length }, (_, i) => i);
  }

  onSubmit(){
    this.stars = this.myForm.get('stars')?.value;
    this.mainDescription = this.myForm.get('Main_description')?.value;
    this.shortDescription = this.myForm.get('Short_description')?.value;
    this.addReview(this.shortDescription, this.mainDescription, this.stars);
    this.resetForm();
  }

  addReview(short_description: string, main_description: string, stars: number){
    this.reviewDto.mainDescription = main_description;
    this.reviewDto.shortDescription = short_description;
    this.reviewDto.stars = stars;
    this.reviewDto.score = 0;
    this.reviewDto.username = this.user.username;
    this.reviewDto.userPhoto = this.user.photoUrl;

    this.bookService.apiBooksAddReviewForBookIdPost(this.book.id!, this.reviewDto).subscribe((response: Review) => {
      response.reviewDate = new Date();
      response.likes = 0
      response.dislikes = 0
      this.reviews.push(response);
      
      this.toastr.success("Review added successfully");
    },
    (error) => {
      this.toastr.error("Error adding review: " + error);
    });
  }

  onRatingChanged(rating: number): void {
    this.myForm.controls['stars'].setValue(rating); 
  }

  resetForm(): void {
    // Reset form fields after submission
    this.starRating.resetStars();
    this.myForm.controls['Main_description'].setValue(''); 
    this.myForm.controls['Short_description'].setValue(''); 
  }

  likeReview(review: Review){
    this.bookService.apiBooksLikeReviewForReviewIdPost(review.reviewId!, this.book.id).subscribe(
      () => {
        review.likes!++; 
      }
    );
  }

  dislikeReview(review: Review){
    this.bookService.apiBooksDislikeReviewForReviewIdPost(review.reviewId!, this.book.id).subscribe(
      () => {
        review.likes!--;
      }
    );
  }

  getReviewLikes(review: Review){
    this.bookService.apiBooksLikeReviewForReviewIdPost(review.reviewId!, this.book.id).subscribe(
      (likes: number) => {
        review.likes = likes;
      }
    );
  }

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: true,
    navSpeed: 700,
    navText: ['&#8249', '&#8250;'],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    },
    nav: true
  }


}
