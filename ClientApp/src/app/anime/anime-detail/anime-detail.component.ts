import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { AnimeService } from 'api/anime.service';
import { Datum } from 'model/datum';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';

@Component({
  selector: 'app-anime-detail',
  templateUrl: './anime-detail.component.html',
  styleUrls: ['./anime-detail.component.scss']
})
export class AnimeDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  
  images : any;

  sanit!: DomSanitizer;
  anime!: Datum;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;
  
  constructor(private animeService: AnimeService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private animeAngularService: AnimeAngularService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) {
      this.sanit = sanitizer;
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
     }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.anime = data['anime'];
      
      // this.anime.actorList = this.anime.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.anime.actorList?.map((n) => n.image);

      this.animeService.apiAnimeAnimeAlreadyAddedGet(this.anime.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteAnime(anime: Datum){
    this.animeAngularService.deleteAnimeForUser(anime.id!).subscribe(() => {
      this.toastr.success("You have deleted " + anime.title);
    })

    this.res = false;
  };

  loadAnime(){
    this.animeService.getAnime(this.route.snapshot.paramMap.get('title')!).subscribe(anime => {
      this.anime = anime;
    })
  }

  addAnime(anime: Datum){
    this.animeAngularService.addAnime(anime.id!).subscribe(() => {
      this.toastr.success("You have added " + anime.title);
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
