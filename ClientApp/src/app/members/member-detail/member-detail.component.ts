import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AnimeService } from 'api/anime.service';
import { FriendsService } from 'api/friends.service';
import { GameService } from 'api/game.service';
import { MangaService } from 'api/manga.service';
import { MoviesService } from 'api/movies.service';
import { TvShowsService } from 'api/tvShows.service';
import { Movie } from 'model/movie';
import { TvShow } from 'model/tvShow';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { AnimeCard } from 'src/app/_models/animeCard';
import { GameCard } from 'src/app/_models/gameCard';
import { MangaCard } from 'src/app/_models/mangaCard';
import { Member } from 'src/app/_models/member';
import { Message } from 'src/app/_models/message';
import { MovieCard } from 'src/app/_models/movieCard';
import { TvShowCard } from 'src/app/_models/tvShowCard';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { MessageService } from 'src/app/_services/message.service';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';
import { PresenceService } from 'src/app/_services/presence.service';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
  providers:[
    MoviesService,
    AnimeService,
    MangaService,
    GameService,
    FriendsService,
    TvShowsService
  ]
})
export class MemberDetailComponent implements OnInit, OnDestroy {
  @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
  member!: Member;
  activeTabs!: TabDirective;
  watchedMovies?: MovieCard[];
  watchedTvShows?: TvShowCard[];
  watchedAnime?: AnimeCard[];
  watchedManga?: MangaCard[];
  watchedGame?: GameCard[];
  messages: Message[] = [];
  user!: User;
  areUsersFriends!: boolean;

  constructor(private memberService: MembersService, 
              private route: ActivatedRoute, 
              private messageService: MessageService,
              public presence: PresenceService,
              private accountService: AccountService,
              private moviesService: MoviesService,
              private animesService: AnimeService,
              private gamesService: GameService,
              private mangaService: MangaService,
              private friendsService: FriendsService,
              private tvShowsService: TvShowsService,
              private router: Router,
              private toastr: ToastrService) {
                this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
                this.router.routeReuseStrategy.shouldReuseRoute = () => false;
              }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      console.log(data);
      this.member = data['member'];
    })

    this.route.queryParams.subscribe(params => {
      params['tab'] ? this.selectTab(params['tab']) : this.selectTab(0);
    })

    this.updateWatchList();
    this.areThoseUsersFriends();
  }

  updateWatchList(){
    this.moviesService.apiMoviesGetMoviesForUsernameGet(this.member.userName).subscribe(response => {
      this.watchedMovies = response;
    })

    this.tvShowsService.apiTvShowsGetTvShowsForUsernameGet(this.member.userName).subscribe(response => {
      this.watchedTvShows = response;
    })

    this.animesService.apiAnimeGetAnimesForUsernameGet(this.member.userName).subscribe(response => {
      this.watchedAnime = response;
    })

    this.mangaService.apiMangaGetMangasForUsernameGet(this.member.userName).subscribe(response => {
      this.watchedManga = response;
    })

    this.gamesService.apiGameGetGamesForUsernameGet(this.member.userName).subscribe((response: GameCard[] | undefined) => {
      this.watchedGame = response;
    })
  }

  areThoseUsersFriends(){
    this.friendsService.apiFriendsCheckFriendshipUsernameGet(this.member.userName).subscribe(response => {
      this.areUsersFriends = response;
    })
  }

  loadMember(){
    this.memberService.getMember(this.route.snapshot.paramMap.get('userName')!).subscribe(member => {
      this.member = member;
    })
  }

  onTabsActivated(data: TabDirective){
    this.activeTabs = data;

    if(this.activeTabs.heading === 'Messages' && this.messages.length === 0){
      this.messageService.createHubConnection(this!.user, this.member.userName);
    } else {
      this.messageService.stopHubConnection();
    }
  }

  ngOnDestroy(): void {
    this.messageService.stopHubConnection();
  }

  selectTab(tabId: number){
    this.memberTabs.tabs[tabId].active = true;
  }
  
  loadMessages(){
    this.messageService.getMessageThread(this.member.userName).subscribe(messages => {
      this.messages = messages;
    })
  }

  addFriend(member: Member){
    this.memberService.addFriend(member.userName).subscribe(() => {
      this.toastr.success('You have send a friend request to ' + member.userName);
    })
  }

}
