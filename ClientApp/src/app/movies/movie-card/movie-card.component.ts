import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { MoviesService } from 'src/app/_services/movies.service';
import { PresenceService } from 'src/app/_services/presence.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  //@Input() movie!: Movie;

  constructor(private movieService: MoviesService,
    private toastr: ToastrService,
    public presence: PresenceService) { }

  ngOnInit(): void {
  }

}
