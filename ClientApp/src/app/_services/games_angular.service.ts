import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AnimeService } from 'api/anime.service';
import { GameService } from 'api/game.service';
import { Datum } from 'model/datum';
import { Game } from 'model/game';
import { map, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AnimeParams } from '../_models/animeParams';
import { GameParams } from '../_models/gameParams';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';
import { ObjectId } from 'model/objectId';

@Injectable({
  providedIn: 'root'
})
export class GamesAngularService {

  baseUrl = environment.apiUrl;
  game!: Game;
  gameParams!: GameParams;
  user!: User;
  gameCache = new Map();
  userParams!: UserParams;
  searchedGame = "";
  
  constructor(private http: HttpClient, private accountService: AccountService, private gameService: GameService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
      this.user = user;
      this.gameParams = new GameParams(user, this.searchedGame);
    })
   }

   getGameParams(){
    return this.gameParams;
  }

  setGameParams(params: GameParams){
    this.gameParams = params;
  }

   resetGameParams(){
    this.searchedGame = "";
    this.gameParams = new GameParams(this.user, this.searchedGame);
    return this.gameParams;
   }

   getGames(gameParams: GameParams) {
    var response = this.gameCache.get(Object.values(gameParams).join('-'));

    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(gameParams.pageNumber, gameParams.pageSize);

    params = params.append('searchedGame', gameParams.searchedGame);
    params = params.append('orderBy', gameParams.orderBy);

    return getPaginatedResult<Datum[]>(this.baseUrl + 'Game/GetAllgames', params, this.http).
      pipe(map(response => {
        this.gameCache.set(Object.values(gameParams).join('-'), response);
        return response;
      }))
  }

  getGame(title: string) {
    const game = [...this.gameCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((game : Game) => game.name === title);

    if(game){
      return of(game);
    }

    return this.http.get<Datum>(this.baseUrl + "Game/" + title);
  }

  addGame(gameId: ObjectId){
    return this.gameService.apiGameAddGameGameIdPost(gameId);
  }

  getGamesForUser(predicate: string, pageNumber: number, pageSize: number){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('predicate', predicate);

    return getPaginatedResult<Partial<Datum[]>>(this.baseUrl + 'Game/GetGamesFor', params, this.http);
  }

  deleteGameForUser(gameId: ObjectId){
    return this.http.delete(this.baseUrl + 'Game/' + gameId);
  }
}
