import { Injectable } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  baseUrl = environment.apiUrl;
  movies: Movie[] = [];
  
  constructor() { }

  getTop250Movies(){
   // return this.http.get(this.baseUrl + 'Top250Movies');
  }

}
