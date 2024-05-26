import { Component, OnInit } from '@angular/core';
import { MangaService } from 'api/manga.service';
import { MangaCard } from 'src/app/_models/mangaCard';
import { MangaParams } from 'src/app/_models/mangaParams';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';

@Component({
  selector: 'app-manga-list',
  templateUrl: './manga-list.component.html',
  styleUrls: ['./manga-list.component.css'],
  providers: [MangaService, MangaAngularService]
})
export class MangaListComponent implements OnInit {

  mangas!: MangaCard[];
  pagination!: Pagination;
  mangaParams!: MangaParams;
  user!: User;
  p?: string | number | undefined = 1;
  searcheManga = "";

  constructor(private mangaAngularService: MangaAngularService) {
    this.mangaParams = this.mangaAngularService.getMangaParams();
   }

  ngOnInit(): void {
    this.loadMangas();
  }

  loadMangas(){
    this.mangaAngularService.setMangaParams(this.mangaParams);

    this.mangaAngularService.getMangas(this.mangaParams).subscribe(response => {
      this.mangas = response.result!;
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.mangaParams = this.mangaAngularService.resetMangaParams();
    this.loadMangas();
  }

  pageChanged(event: any){
    this.mangaParams.pageNumber = event.page;
    this.mangaAngularService.setMangaParams(this.mangaParams);
    this.loadMangas();
  }


}
