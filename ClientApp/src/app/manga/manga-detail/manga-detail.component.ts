import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'api/account.service';
import { MangaService } from 'api/manga.service';
import { DatumManga } from 'model/datumManga';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';

@Component({
  selector: 'app-manga-detail',
  templateUrl: './manga-detail.component.html',
  styleUrls: ['./manga-detail.component.scss']
})
export class MangaDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  
  images : any;

  sanit!: DomSanitizer;
  manga!: DatumManga;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;
  
  constructor(private mangaService: MangaService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private mangaAngularService: MangaAngularService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.manga = data['manga'];
      
      console.log(this.manga);
      
      // this.anime.actorList = this.anime.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.anime.actorList?.map((n) => n.image);

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
