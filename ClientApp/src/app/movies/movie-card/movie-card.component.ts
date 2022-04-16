import { Component, Input, OnInit } from '@angular/core';
import { MovieItem } from 'model/movieItem';
import { MoviesService } from 'api/movies.service';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { PresenceService } from 'src/app/_services/presence.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie!: MovieItem;

  constructor(private movieService: MoviesService,
    private toastr: ToastrService,
    public presence: PresenceService) { }

  ngOnInit(): void {
  }

  addMovie(movie: MovieItem){

  }

}
