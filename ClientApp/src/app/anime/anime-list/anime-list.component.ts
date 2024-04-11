import { Component, OnInit } from '@angular/core';
import { AnimeService } from 'api/anime.service';
import { AnimeCard } from 'src/app/_models/animeCard';
import { AnimeParams } from 'src/app/_models/animeParams';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { AnimeAngularService } from 'src/app/_services/anime_angular.service';

@Component({
  selector: 'app-anime-list',
  templateUrl: './anime-list.component.html',
  styleUrls: ['./anime-list.component.css'],
  providers: [AnimeAngularService, AnimeService]
})
export class AnimeListComponent implements OnInit {

  animes!: AnimeCard[];
  pagination!: Pagination;
  animeParams!: AnimeParams;
  user!: User;
  p?: string | number | undefined = 1;
  searcheAnime = "";

  constructor(private animeAngularService: AnimeAngularService) {
    this.animeParams = this.animeAngularService.getAnimeParams();
   }

  ngOnInit(): void {
    this.loadAnimes();
  }

  loadAnimes(){
    this.animeAngularService.setAnimeParams(this.animeParams);

    this.animeAngularService.getAnimes(this.animeParams).subscribe(response => {
      this.animes = response.result!;
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.animeParams = this.animeAngularService.resetAnimeParams();
    this.loadAnimes();
  }

  pageChanged(event: any){
    this.animeParams.pageNumber = event.page;
    this.animeAngularService.setAnimeParams(this.animeParams);
    this.loadAnimes();
  }

}
