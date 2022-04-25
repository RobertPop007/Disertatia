import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, ActivationStart, ChildActivationEnd, NavigationEnd, ResolveStart, Router } from '@angular/router';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { MovieItem } from 'model/movieItem';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { filter, map, take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;


  movie!: Movie;
  activeTabs!: TabDirective;
  user!: User;

  images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);
  
  constructor(private movieService: MoviesService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router) {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
     }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.movie = data['movie'];
      
      this.movie.actorList?.sort((a, b) => a.id!.localeCompare(b.id!));
    })

    this.route.queryParams.subscribe(params => {
      params['tab'] ? this.selectTab(params['tab']) : this.selectTab(0);
    })
  }

  loadMovie(){
    console.log(this.route.snapshot.paramMap.get('fullTitle'));
    
    this.movieService.getMovie(this.route.snapshot.paramMap.get('fullTitle')!).subscribe(movie => {
      this.movie = movie;
      console.log(this.movie);
      
    })
  }

  onTabsActivated(data: TabDirective){
    this.activeTabs = data;
  }

  selectTab(tabId: number){
    this.memberTabs.tabs[tabId].active = true;
  }

  toggleVideo() {
    this.videoplayer.nativeElement.play();
}

}
