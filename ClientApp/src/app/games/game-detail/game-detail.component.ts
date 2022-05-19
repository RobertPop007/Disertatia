import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'api/account.service';
import { GameService } from 'api/game.service';
import { Game } from 'model/game';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { GamesAngularService } from 'src/app/_services/games_angular.service';

@Component({
  selector: 'app-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: ['./game-detail.component.scss']
})
export class GameDetailComponent implements OnInit {

  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  @ViewChild('videoPlayer') videoplayer!: ElementRef;
  
  images : any;

  sanit!: DomSanitizer;
  game!: Game;
  activeTabs!: TabDirective;
  user!: User;
  res!: boolean;
  
  constructor(private gameService: GameService, 
    private route: ActivatedRoute, 
    private accountService: AccountService,
    private router: Router,
    private gameAngularService: GamesAngularService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.game = data['game'];
      
      console.log(this.game);
      
      // this.anime.actorList = this.anime.actorList?.sort((a, b) => a.id!.localeCompare(b.id!)).slice(0, 20);

      // this.images = this.anime.actorList?.map((n) => n.image);

      this.gameService.apiGameGameAlreadyAddedGet(this.game.id!).pipe(take(1)).subscribe(res => {
        this.res = res;
      })
    })
  }

  deleteGame(game: Game){
    this.gameAngularService.deleteGameForUser(game.id!).subscribe(() => {
      this.toastr.success("You have deleted " + game.name);
    })

    this.res = false;
  };

  loadMGame(){
    this.gameService.getGame(this.route.snapshot.paramMap.get('name')!).subscribe(game => {
      this.game = game;
    })
  }

  addGame(game: Game){
    this.gameAngularService.addGame(game.id!).subscribe(() => {
      this.toastr.success("You have added " + game.name);
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
