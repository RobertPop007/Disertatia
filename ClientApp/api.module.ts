import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import { Configuration } from './configuration';
import { HttpClient } from '@angular/common/http';


import { AccountService } from './api/account.service';
import { AdminService } from './api/admin.service';
import { AnimeService } from './api/anime.service';
import { BuggyService } from './api/buggy.service';
import { FriendsService } from './api/friends.service';
import { GameService } from './api/game.service';
import { MangaService } from './api/manga.service';
import { MessagesService } from './api/messages.service';
import { MoviesService } from './api/movies.service';
import { TvShowsService } from './api/tvShows.service';
import { UsersService } from './api/users.service';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@NgModule({
  imports:      [],
  declarations: [],
  exports:      [],
  providers: [
    AccountService,
    AdminService,
    AnimeService,
    BuggyService,
    FriendsService,
    GameService,
    MangaService,
    MessagesService,
    MoviesService,
    TvShowsService,
    UsersService,
    TvShowsAngularService ]
})
export class ApiModule {
    public static forRoot(configurationFactory: () => Configuration): ModuleWithProviders<ApiModule> {
        return {
            ngModule: ApiModule,
            providers: [ { provide: Configuration, useFactory: configurationFactory } ]
        };
    }

    constructor( @Optional() @SkipSelf() parentModule: ApiModule,
                 @Optional() http: HttpClient) {
        if (parentModule) {
            throw new Error('ApiModule is already loaded. Import in your base AppModule only.');
        }
        if (!http) {
            throw new Error('You need to import the HttpClientModule in your AppModule! \n' +
            'See also https://github.com/angular/angular/issues/20575');
        }
    }
}
