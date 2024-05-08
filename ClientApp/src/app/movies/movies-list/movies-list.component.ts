import { Component, OnInit } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { NgxSpinnerService } from 'ngx-spinner';
import { MovieCard } from 'src/app/_models/movieCard';
import { MovieParams } from 'src/app/_models/movieParams';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css'],
  providers: [MoviesAngularService, MoviesService]
})
export class MoviesListComponent implements OnInit {
  movies!: MovieCard[];
  pagination!: Pagination;
  movieParams!: MovieParams;
  user!: User;
  p?: string | number | undefined = 1;
  searchedMovie = "";

  constructor(private moviesAngularService: MoviesAngularService) {
    this.movieParams = this.moviesAngularService.getMovieParams();
   }

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies(){
    this.moviesAngularService.setMovieParams(this.movieParams);

    this.moviesAngularService.getMovies(this.movieParams).subscribe(response => {
      this.movies = response.result!;
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.movieParams = this.moviesAngularService.resetMovieParams();
    this.loadMovies();
  }

  pageChanged(event: any){
    this.movieParams.pageNumber = event.page;
    this.moviesAngularService.setMovieParams(this.movieParams);
    this.loadMovies();
  }

}
