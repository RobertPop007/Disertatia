import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { MangaService } from 'api/manga.service';
import { UsersService } from 'api/users.service';
import { DatumManga } from 'model/datumManga';
import { MemberDto } from 'model/memberDto';
import { Review } from 'model/review';
import { ReviewDto } from 'model/reviewDto';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { MangaDetailedResolver } from 'src/app/_resolvers/manga-detailed.resolver';
import { AccountService } from 'src/app/_services/account.service';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';
import { StarRatingComponent } from 'src/app/helpers/star-rating/star-rating.component';

@Component({
  selector: 'app-manga-detail',
  templateUrl: './manga-detail.component.html',
  styleUrls: ['./manga-detail.component.scss'],
  providers: [
    MangaDetailedResolver,
    MangaService,
    MangaAngularService,
    UsersService
  ]
})
export class MangaDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  @ViewChild('starRating') starRating!: StarRatingComponent;
  
  images : any;

  sanit!: DomSanitizer;
  manga!: DatumManga;
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
  
  constructor(private mangaService: MangaService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private mangaAngularService: MangaAngularService,
    private userService: UsersService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer,
    private fb: FormBuilder) {
      this.sanit = sanitizer;
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      console.log(this.user) 
    }

  ngOnInit(): void {
    this.myForm = this.fb.group({
      Short_description: ['', Validators.required],
      Main_description: ['', [Validators.required]],
      stars: ['', Validators.required]
    });
    
    this.route.data.subscribe(data => {
      this.manga = data['manga'];
      
      console.log(this.manga);
      
      // this.anime.actorList = this.anime.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.anime.actorList?.map((n) => n.image);
      this.getReviews();
      this.mangaService.apiMangaMangaAlreadyAddedGet(this.manga.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteManga(manga: DatumManga){
    this.mangaAngularService.deleteMangaForUser(manga.id!).subscribe(() => {
      this.toastr.success("You have deleted " + manga.title);
    })

    this.res = false;
  };

  loadManga(){
    this.mangaService.getManga(this.route.snapshot.paramMap.get('title')!).subscribe(manga => {
      this.manga = manga;
    })
  }

  addManga(manga: DatumManga){
    this.mangaAngularService.addManga(manga.id!).subscribe(() => {
      this.toastr.success("You have added " + manga.title);
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
    this.mangaService.apiMangaGetReviewsForMangaIdGet(this.manga.id!).subscribe(reviews => {
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

    this.mangaService.apiMangaAddReviewForMangaIdPost(this.manga.id!, this.reviewDto).subscribe((response: Review) => {
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
    this.mangaService.apiMangaLikeReviewForReviewIdPost(review.reviewId!, this.manga.id).subscribe(
      () => {
        review.likes!++; 
      }
    );
  }

  dislikeReview(review: Review){
    this.mangaService.apiMangaDislikeReviewForReviewIdPost(review.reviewId!, this.manga.id).subscribe(
      () => {
        review.dislikes!++;
      }
    );
  }

  getReviewLikes(review: Review){
    this.mangaService.apiMangaLikeReviewForReviewIdPost(review.reviewId!, this.manga.id).subscribe(
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
