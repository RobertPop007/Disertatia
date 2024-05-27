import { Component, Input, OnInit, Output } from '@angular/core';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { ToastrService } from 'ngx-toastr';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-movie-card-added',
  templateUrl: './movie-card-added.component.html',
  styleUrls: ['./movie-card-added.component.scss']
})
export class MovieCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() movie!: Movie;
  movieAlreadyAdded!: boolean;

  constructor(private movieAngularService: MoviesAngularService,
    private movieService: MoviesService,
    private toastr: ToastrService) {
    }

  ngOnInit(): void {
    console.log(this.movie)
  }

  deleteMovieForUser(movie: Movie){
    this.movieAngularService.deleteMovieForUser(movie.id!).subscribe(() => {
      this.toastr.success("You have deleted " + movie.title);

      this.deleteEvent.emit("This value is coming from child");
    });
  }
}
