import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AnimeService } from 'api/anime.service';
import { Datum } from 'model/datum';
import { map, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AnimeParams } from '../_models/animeParams';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';
import { ObjectId } from 'model/objectId';

@Injectable({
  providedIn: 'root'
})
export class AnimeAngularService {

  baseUrl = environment.apiUrl;
  anime!: Datum;
  animeParams!: AnimeParams;
  user!: User;
  animeCache = new Map();
  userParams!: UserParams;
  searchedAnime = "";
  
  constructor(private http: HttpClient, private accountService: AccountService, private animeService: AnimeService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
      this.user = user;
      this.animeParams = new AnimeParams(user, this.searchedAnime);
    })
   }

   getAnimeParams(){
    return this.animeParams;
  }

  setAnimeParams(params: AnimeParams){
    this.animeParams = params;
  }

   resetAnimeParams(){
    this.searchedAnime = "";
    this.animeParams = new AnimeParams(this.user, this.searchedAnime);
    return this.animeParams;
   }

   getAnimes(animeParams: AnimeParams) {
    var response = this.animeCache.get(Object.values(animeParams).join('-'));

    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(animeParams.pageNumber, animeParams.pageSize);

    params = params.append('searchedAnime', animeParams.searchedAnime);
    params = params.append('orderBy', animeParams.orderBy);

    return getPaginatedResult<Datum[]>(this.baseUrl + 'Anime/GetAllAnimes', params, this.http).
      pipe(map(response => {
        this.animeCache.set(Object.values(animeParams).join('-'), response);
        return response;
      }))
  }

  getAnime(title: string) {
    const anime = [...this.animeCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((anime : Datum) => anime.title === title);

    if(anime){
      return of(anime);
    }

    return this.http.get<Datum>(this.baseUrl + "Anime/" + title);
  }

  addAnime(animeId: ObjectId){
    return this.animeService.apiAnimeAddAnimeAnimeIdPost(animeId);
  }

  getAnimesForUser(predicate: string, pageNumber: number, pageSize: number){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('predicate', predicate);

    return getPaginatedResult<Partial<Datum[]>>(this.baseUrl + 'Anime/GetAnimesFor', params, this.http);
  }

  deleteAnimeForUser(animeId: ObjectId){
    return this.http.delete(this.baseUrl + 'Anime/' + animeId);
  }
}
