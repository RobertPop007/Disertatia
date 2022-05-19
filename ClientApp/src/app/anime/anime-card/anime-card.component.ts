import { Component, Input, OnInit } from '@angular/core';
import { AnimeService } from 'api/anime.service';
import { Datum } from 'model/datum';
import { ToastrService } from 'ngx-toastr';
import { AnimeCard } from 'src/app/_models/animeCard';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';

@Component({
  selector: 'app-anime-card',
  templateUrl: './anime-card.component.html',
  styleUrls: ['./anime-card.component.scss']
})
export class AnimeCardComponent implements OnInit {
  @Input() anime!: AnimeCard;

  constructor(private animeAngularService: AnimeAngularService,
    private animeService: AnimeService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addAnime(anime: Datum){
    this.animeAngularService.addAnime(anime.mal_id!).subscribe(() => {
      this.toastr.success("You have added " + anime.title);
    })
  }

  isAnimeAlreadyAdded(animeId: number): boolean{
    this.animeService.apiAnimeAnimeAlreadyAddedGet(animeId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
