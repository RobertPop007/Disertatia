import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, ActivationStart, ChildActivationEnd, NavigationEnd, ResolveStart, Router } from '@angular/router';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { filter, first, map, take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;

  images : any;

  sanit!: DomSanitizer;
  movie!: Movie;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;
  
  constructor(private movieService: MoviesService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private movieAngularService: MoviesAngularService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) {
      this.sanit = sanitizer;
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
     }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.movie = data['movie'];

      console.log(this.movie);
      
      
      // this.movie.actorList = this.movie.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.movie.actorList?.map((n) => n.image);

      this.movieService.apiMoviesMovieAlreadyAddedGet(this.movie.movieId!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteMovie(movie: Movie){
    this.movieAngularService.deleteMovieForUser(movie.movieId!).subscribe(() => {
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
    this.movieAngularService.addMovie(movie.movieId!).subscribe(() => {
      this.toastr.success("You have added " + movie.title);
    })

    this.res = true;
  }

  toggleVideo() {
    this.videoplayer.nativeElement.play();
  }

  cleanURL(oldURL: string): SafeResourceUrl {
    return this.sanit.bypassSecurityTrustResourceUrl(oldURL);
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
