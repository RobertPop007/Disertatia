import { Component, Input, OnInit } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { MovieItem } from 'model/movieItem';
import { listenToTriggers } from 'ngx-bootstrap/utils';
import { ToastrService } from 'ngx-toastr';
import { MovieCard } from 'src/app/_models/movieCard';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie!: MovieCard;

  constructor(private movieAngularService: MoviesAngularService,
    private movieService: MoviesService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addMovie(movie: Movie){
    this.movieAngularService.addMovie(movie.id!).subscribe(() => {
      this.toastr.success("You have added " + movie.fullTitle);
    })
  }

  isMovieAlreadyAdded(movieId: string): boolean{
    this.movieService.apiMoviesMovieAlreadyAddedGet(movieId).subscribe((response) => {
      return response;
    })
    return false;
  }
}
