import { DOCUMENT } from '@angular/common';
import { Component, HostListener, Inject, OnInit, Renderer2, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DarkModeService } from 'angular-dark-mode';
import { AnimeService } from 'api/anime.service';
import { GameService } from 'api/game.service';
import { MangaService } from 'api/manga.service';
import { MoviesService } from 'api/movies.service';
import { TvShowsService } from 'api/tvShows.service';
import { Datum } from 'model/datum';
import { Movie } from 'model/movie';
import { TvShow } from 'model/tvShow';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Theme } from 'src/app/app.component';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { AnimeCard } from 'src/app/_models/animeCard';
import { GameCard } from 'src/app/_models/gameCard';
import { MangaCard } from 'src/app/_models/mangaCard';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';
import { GamesAngularService } from 'src/app/_services/games_angular.service';
import { DatumManga } from 'model/datumManga';
import { Game } from 'model/game';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css'],
  providers: [TvShowsService, TvShowsAngularService,
    MoviesService, MoviesAngularService,
    AnimeService, AnimeAngularService,
    MangaService, MangaAngularService, 
    GamesAngularService, GameService
  ]
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm!: NgForm;
  member!: Member;
  user!: User;
  theme: Theme = 'light-theme';
  watchedMovies?: Movie[];
  watchedTvShows?: TvShow[];
  watchedAnime?: Datum[];
  watchedManga?: DatumManga[];
  watchedGame?: Game[];
  predicate = 'added';
  pageNumber = 1;
  isDarkMode!: boolean;
  pageSize = 5;
  pagination!: Pagination;

  checked = false;
  isSubscribed!: boolean;
  disabled = false;
  
  
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if(this.editForm.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountAngularService: AccountService,
              private memberService: MembersService,
              private tvShowsService: TvShowsService,
              private router: Router,
              private moviesService: MoviesService,
              private animesService: AnimeService,
              private gamesService: GameService,
              private mangaService: MangaService,
              public dialog: MatDialog,
              private toastr: ToastrService,
              private darkModeService: DarkModeService,
              private renderer: Renderer2,
              @Inject(DOCUMENT) private document: Document) {
                this.accountAngularService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
               }

  ngOnInit(): void {
    this.loadMember();
    this.updateWatchList();

    if(this.isDarkMode === true)
    {
      this.darkModeService.enable();
    }

    this.initializeTheme();

    this.isSubscribed = this.user.isSubscribed;
    this.isDarkMode = this.user.hasDarkMode;

    this.document.body.classList.replace(
      this.theme, 
      this.isDarkMode === true
      ? (this.theme = 'dark-theme') 
      : (this.theme = 'light-theme'))
  }

  getState(): boolean{
    return this.isSubscribed;
  }

  getTheme(): boolean{
    return this.isDarkMode;
  }


  subcribeToNewsletter(username: string){

    this.accountAngularService.subscribe(username);

    this.isSubscribed = !this.isSubscribed;
    localStorage.setItem('isSubscribed', JSON.stringify(this.isSubscribed));

    let user = JSON.parse(localStorage.getItem('user')!);

    var boolValue = JSON.parse(localStorage.getItem('isSubscribed')!);

    user['isSubscribed'] = boolValue;
    localStorage.setItem('user', JSON.stringify(user));
  }

  enabledDarkMode(username: string){
    this.accountAngularService.enableDarkMode(username);

    this.isDarkMode = !this.isDarkMode;
    localStorage.setItem('isDarkMode', JSON.stringify(this.isDarkMode));

    let user = JSON.parse(localStorage.getItem('user')!);

    var boolValue = JSON.parse(localStorage.getItem('isDarkMode')!);

    user['hasDarkMode'] = boolValue;
    localStorage.setItem('user', JSON.stringify(user));

    this.document.body.classList.replace(
      this.theme, 
      localStorage.getItem('isDarkMode') === 'true'
      ? (this.theme = 'dark-theme') 
      : (this.theme = 'light-theme'))
  }

  deleteAccount(username: string){
    const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: "Confirm",
        message: "Are you sure you want to delete your own account?"
      }
    })

    confirmDialog.afterClosed().subscribe(result => {
      if (result === true) {
        
        this.accountAngularService.deleteAccount(username);
        this.accountAngularService.logout();
        this.router.navigateByUrl('/');
      }
    });
  }

  initializeTheme = (): void =>
      this.renderer.addClass(this.document.body, this.theme);

  // switchTheme(){
  //   this.document.body.classList.replace(
  //     this.theme, 
  //     this.theme === 'light-theme' 
  //     ? (this.theme = 'dark-theme') 
  //     : (this.theme = 'light-theme'))


  //     this.isDarkMode = !this.isDarkMode;
  //     localStorage.setItem('isDarkMode', JSON.stringify(this.isDarkMode));
  // }

  setDisplayMode(mode: string) {
    localStorage.setItem("isDarkMode", mode);
  }


  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    })
  }

  updateMember(){
    this.memberService.updateMember(this.member).subscribe(() => {
      this.toastr.success('Profile updated successfully');
      this.editForm.reset(this.member);
    })
  }

  updateWatchList(){
    this.moviesService.apiMoviesGetMoviesForUsernameGet(this.user.username).subscribe(response => {
      this.watchedMovies = response;
    })

    this.tvShowsService.apiTvShowsGetTvShowsForUsernameGet(this.user.username).subscribe(response => {
      this.watchedTvShows = response;
    })

    this.animesService.apiAnimeGetAnimesForUsernameGet(this.user.username).subscribe(response => {
      this.watchedAnime = response;
    })

    this.mangaService.apiMangaGetMangasForUsernameGet(this.user.username).subscribe(response => {
      this.watchedManga = response;
    })

    this.gamesService.apiGameGetGamesForUsernameGet(this.user.username).subscribe(response => {
      this.watchedGame = response;
    })
  }
}
