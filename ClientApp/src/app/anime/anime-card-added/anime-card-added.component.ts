import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Datum } from 'model/datum';
import { ToastrService } from 'ngx-toastr';
import { AnimeCard } from 'src/app/_models/animeCard';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';

@Component({
  selector: 'app-anime-card-added',
  templateUrl: './anime-card-added.component.html',
  styleUrls: ['./anime-card-added.component.scss']
})
export class AnimeCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() anime!: Datum;
  animeAlreadyAdded!: boolean;
  
  constructor(private animeAngularService: AnimeAngularService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  deleteAnimeForUser(anime: Datum){
    this.animeAngularService.deleteAnimeForUser(anime.id!).subscribe(() => {
      this.toastr.success("You have deleted " + anime.title);

      this.deleteEvent.emit("This value is coming from child");
    });
  }

}
