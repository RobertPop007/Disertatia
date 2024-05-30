import { Component, Input, OnInit } from '@angular/core';
import { AnimeService } from 'api/anime.service';
import { Datum } from 'model/datum';
import { ObjectId } from 'model/objectId';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { AnimeCard } from 'src/app/_models/animeCard';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';

@Component({
  selector: 'app-anime-card',
  templateUrl: './anime-card.component.html',
  styleUrls: ['./anime-card.component.scss']
})
export class AnimeCardComponent implements OnInit {
  @Input() anime!: AnimeCard;
  res!: boolean;

  constructor(private animeAngularService: AnimeAngularService,
    private animeService: AnimeService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.animeService.apiAnimeAnimeAlreadyAddedGet(this.anime.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addAnime(anime: Datum){
    this.animeAngularService.addAnime(anime.id!).subscribe(() => {
      this.toastr.success("You have added " + anime.title);
    })

    this.res = true;
  }

  deleteAnime(anime: Datum){
    this.animeAngularService.deleteAnimeForUser(anime.id!).subscribe(() => {
      this.toastr.success("You have deleted " + anime.title);
    })

    this.res = false;
  }

  isAnimeAlreadyAdded(animeId: ObjectId): boolean{
    this.animeService.apiAnimeAnimeAlreadyAddedGet(animeId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
