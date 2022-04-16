import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { MovieParams } from '../_models/movieParams';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class MoviesAngularService{

  baseUrl = environment.apiUrl;
  movie!: Movie;
  movieParams!: MovieParams;
  user!: User;
  movieCache = new Map();
  userParams!: UserParams;
  searchedMovie = "";

  constructor(private http: HttpClient, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
      this.user = user;
      this.movieParams = new MovieParams(user, this.searchedMovie);
    })
   }

   getMovieParams(){
    return this.movieParams;
  }

  setMovieParams(params: MovieParams){
    this.movieParams = params;
  }

   resetMovieParams(){
    this.searchedMovie = "";
    this.movieParams = new MovieParams(this.user, this.searchedMovie);
    return this.movieParams;
   }

   getMovies(movieParams: MovieParams) {
    var response = this.movieCache.get(Object.values(movieParams).join('-'));

    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(movieParams.pageNumber, movieParams.pageSize);

    params = params.append('searchedMovie', movieParams.searchedMovie);
    params = params.append('orderBy', movieParams.orderBy);

    return getPaginatedResult<Movie[]>(this.baseUrl + 'Movies/GetAllMovies', params, this.http).
      pipe(map(response => {
        this.movieCache.set(Object.values(movieParams).join('-'), response);
        return response;
      }))
  }

  getMovie(fullTitle: string) {
    const movie = [...this.movieCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((movie : Movie) => movie.fullTitle === fullTitle);

    if(movie){
      return of(movie);
    }

    return this.http.get<Movie>(this.baseUrl + fullTitle);
  }

  addMovie(movieId: string){
    return this.http.post(this.baseUrl + 'AddMovie/' + movieId, {});
  }

  getMoviesForUser(predicate: string, pageNumber: number, pageSize: number){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('predicate', predicate);

    return getPaginatedResult<Partial<Movie[]>>(this.baseUrl + 'GetMoviesFor', params, this.http);
  }
}
