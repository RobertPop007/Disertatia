import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { TvShowsService } from 'api/tvShows.service';
import { Movie } from 'model/movie';
import { TvShow } from 'model/tvShow';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-tv-show-detail',
  templateUrl: './tv-show-detail.component.html',
  styleUrls: ['./tv-show-detail.component.scss']
})
export class TvShowDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  
  images : any;

  sanit!: DomSanitizer;
  tvShow!: TvShow;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;

  constructor(private tvShowService: TvShowsService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private tvShowAngularService: TvShowsAngularService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) {
      this.sanitizer = sanitizer;
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
     }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.tvShow = data['tvShow'];
      
      this.tvShow.actorList = this.tvShow.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      this.images = this.tvShow.actorList?.map((n) => n.image);

      this.tvShowService.apiTvShowsTvShowAlreadyAddedGet(this.tvShow.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteTvShow(tvShow: Movie){
    this.tvShowAngularService.deleteTvShowForUser(tvShow.id!).subscribe(() => {
      this.toastr.success("You have deleted " + tvShow.fullTitle);
    })

    this.res = false;
  };

  loadTvShow(){
    this.tvShowService.getTvShow(this.route.snapshot.paramMap.get('title')!).subscribe(tvShow => {
      this.tvShow = tvShow;
    })
  }

  addTvShow(tvShow: TvShow){
    this.tvShowAngularService.addTvShow(tvShow.id!).subscribe(() => {
      this.toastr.success("You have added " + tvShow.fullTitle);
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
