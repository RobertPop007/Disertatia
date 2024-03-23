import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { TvShowsService } from 'api/tvShows.service';
import { TvShow } from 'model/tvShow';
import { map, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { MovieParams } from '../_models/movieParams';
import { TvShowParams } from '../_models/tvShowParams';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class TvShowsAngularService{

  baseUrl = environment.apiUrl;
  tvShow!: TvShow;
  tvShowParams!: TvShowParams;
  user!: User;
  tvShowCache = new Map();
  userParams!: UserParams;
  searchedTvShow = "";

  constructor(private http: HttpClient, private accountService: AccountService, private tvShowService: TvShowsService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
      this.user = user;
      this.tvShowParams = new TvShowParams(user, this.searchedTvShow);
    })
   }

   getTvShowParams(){
    return this.tvShowParams;
  }

  setTvShowParams(params: TvShowParams){
    this.tvShowParams = params;
  }

   resetTvShowParams(){
    this.searchedTvShow = "";
    this.tvShowParams = new TvShowParams(this.user, this.searchedTvShow);
    return this.tvShowParams;
   }

   getTvShows(tvShowParams: TvShowParams) {
    var response = this.tvShowCache.get(Object.values(tvShowParams).join('-'));

    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(tvShowParams.pageNumber, tvShowParams.pageSize);

    params = params.append('searchedMovie', tvShowParams.searchedTvShow);
    params = params.append('orderBy', tvShowParams.orderBy);

    return getPaginatedResult<TvShow[]>(this.baseUrl + 'TvShows/GetAllTvShows', params, this.http).
      pipe(map(response => {
        this.tvShowCache.set(Object.values(tvShowParams).join('-'), response);
        return response;
      }))
  }

  getTvShow(fullTitle: string) {
    const tvShow = [...this.tvShowCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((movie : TvShow) => tvShow.fullTitle === fullTitle);

    if(tvShow){
      return of(tvShow);
    }

    return this.http.get<TvShow>(this.baseUrl + "TvShows/" + fullTitle);
  }

  addTvShow(tvShowId: string){
    return this.tvShowService.apiTvShowsAddTvShowTvShowIdPost(tvShowId);
  }

  getTvShowsForUser(predicate: string, pageNumber: number, pageSize: number){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('predicate', predicate);

    return getPaginatedResult<Partial<TvShow[]>>(this.baseUrl + 'TvShows/GetTvShowsFor', params, this.http);
  }

  deleteTvShowForUser(tvShowId: string){
    return this.http.delete(this.baseUrl + 'TvShows/' + tvShowId);
  }
}
