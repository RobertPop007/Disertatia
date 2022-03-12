import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { MoviesService } from 'src/app/_services/movies.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  movies!: Movie[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    //this.loadMovies();
  }

  loadMovies(){
    //return this.moviesService.getTop250Movies();
  }

}
