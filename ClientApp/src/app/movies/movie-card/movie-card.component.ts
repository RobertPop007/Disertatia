import { Component, Input, OnInit } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { ObjectId } from 'model/objectId';
import { Similar } from 'model/similar';
import { listenToTriggers } from 'ngx-bootstrap/utils';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { MovieCard } from 'src/app/_models/movieCard';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie!: MovieCard;
  res!: boolean;

  constructor(private movieAngularService: MoviesAngularService,
    private movieService: MoviesService,
    private toastr: ToastrService) {
    }

  ngOnInit(): void {
    this.movieService.apiMoviesMovieAlreadyAddedGet(this.movie.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addMovie(movie: Movie){
    this.movieAngularService.addMovie(movie.id!).subscribe(() => {
      this.toastr.success("You have added " + movie.title);
    })
  }

  deleteMovie(movie: Movie){
    this.movieAngularService.deleteMovieForUser(movie.id!).subscribe(() => {
      this.toastr.success("You have deleted " + movie.title);
    })

    this.res = false;
  }

  isMovieAlreadyAdded(movieId: ObjectId): boolean{
    this.movieService.apiMoviesMovieAlreadyAddedGet(movieId).subscribe((response) => {
      return response;
    })
    return false;
  }
}
