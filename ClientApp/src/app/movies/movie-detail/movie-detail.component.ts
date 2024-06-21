import { Component, ComponentRef, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, ActivationStart, ChildActivationEnd, NavigationEnd, ResolveStart, Router } from '@angular/router';
import { MoviesService } from 'api/movies.service';
import { UsersService } from 'api/users.service';
import { MemberDto } from 'model/memberDto';
import { Movie } from 'model/movie';
import { Review } from 'model/review';
import { ReviewDto } from 'model/reviewDto';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { filter, first, map, take } from 'rxjs';
import { RewardModalComponent } from 'src/app/_modals/reward-modal/reward-modal.component';
import { User } from 'src/app/_models/user';
import { MovieDetailedResolver } from 'src/app/_resolvers/movie-detailed.resolver';
import { AccountService } from 'src/app/_services/account.service';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';
import { StarRatingComponent } from 'src/app/helpers/star-rating/star-rating.component';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css'],
  providers: [
    MovieDetailedResolver,
    MoviesService,
    MoviesAngularService,
    UsersService
  ]
})
export class MovieDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  @ViewChild('starRating') starRating!: StarRatingComponent;
  // @ViewChild('modalContainer', { read: ViewContainerRef }) modalContainer: ViewContainerRef;
  modalRef!: ComponentRef<RewardModalComponent>;

  images : any;

  sanit!: DomSanitizer;
  movie!: Movie;
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
  videoUrl!: string;
  bsModalRef!: BsModalRef;
  
  constructor(private movieService: MoviesService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private movieAngularService: MoviesAngularService,
    private userService: UsersService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer,
    private modalService: BsModalService,
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
      this.movie = data['movie'];
      console.log(this.movie)

      const videoResults = this.movie.videos?.results;

      if (videoResults && videoResults.length > 0 && videoResults[0].key) {
          const videoKey = videoResults[0].key;
          this.videoUrl = `https://www.youtube.com/embed/${videoKey}?enablejsapi=1&wmode=opaque&autoplay=1`;
      }
      
      // this.movie.actorList = this.movie.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.movie.actorList?.map((n) => n.image);
      this.getReviews();
      this.movieService.apiMoviesMovieAlreadyAddedGet(this.movie.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteMovie(movie: Movie){
    this.movieAngularService.deleteMovieForUser(movie.id!).subscribe(() => {
      this.toastr.success("You have deleted " + movie.title);
    })

    this.res = false;
  };

  loadMovie(){
    this.movieService.getMovie(this.route.snapshot.paramMap.get('title')!).subscribe(movie => {
      this.movie = movie;
    })
  }

  addMovie(movie: Movie){
    this.movieAngularService.addMovie(movie.id!).subscribe(() => {
      this.toastr.success("You have added " + movie.title);
    })

    this.res = true;

    const config = {
      class: 'modal-dialog-centered',
      initialState: {
      }
    }

    this.bsModalRef = this.modalService.show(RewardModalComponent, config);
  }

  toggleVideo() {
    this.videoplayer.nativeElement.play();
  }

  cleanURL(oldURL: string): SafeResourceUrl {
    return this.sanit.bypassSecurityTrustResourceUrl(oldURL);
  }

  getReviews(){
    this.movieService.apiMoviesGetReviewsForMovieIdGet(this.movie.id!).subscribe(reviews => {
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

    this.movieService.apiMoviesAddReviewForMovieIdPost(this.movie.id!, this.reviewDto).subscribe((response: Review) => {
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
    this.movieService.apiMoviesLikeReviewForReviewIdPost(review.reviewId!, this.movie.id).subscribe(
      () => {
        review.likes!++; 
      }
    );
  }

  dislikeReview(review: Review){
    this.movieService.apiMoviesDislikeReviewForReviewIdPost(review.reviewId!, this.movie.id).subscribe(
      () => {
        review.likes!--;
      }
    );
  }

  getReviewLikes(review: Review){
    this.movieService.apiMoviesLikeReviewForReviewIdPost(review.reviewId!, this.movie.id).subscribe(
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
