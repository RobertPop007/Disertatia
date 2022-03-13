import { Component, OnInit } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { MovieItem } from 'model/movieItem';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  movies!: MovieItem[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    this.loadMovies();
    this.movies = this.shuffleArray(this.movies);
  }

  loadMovies(){
    this.moviesService.top250MoviesGet().subscribe(response => {
      this.movies = response;
    })
  }

  shuffleArray(array: MovieItem[]) {
    var m = array.length, t, i;
 
    while (m) {    
     i = Math.floor(Math.random() * m--);
     t = array[m];
     array[m] = array[i];
     array[i] = t;
    }
 
   return array;
 }

}
