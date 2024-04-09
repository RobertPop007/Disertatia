import { Component, Input, OnInit } from '@angular/core';
import { MangaService } from 'api/manga.service';
import { DatumManga } from 'model/datumManga';
import { ObjectId } from 'model/objectId';
import { ToastrService } from 'ngx-toastr';
import { MangaCard } from 'src/app/_models/mangaCard';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';

@Component({
  selector: 'app-manga-card',
  templateUrl: './manga-card.component.html',
  styleUrls: ['./manga-card.component.scss']
})
export class MangaCardComponent implements OnInit {

  @Input() manga!: MangaCard;
  
  constructor(private mangaAngularService: MangaAngularService,
    private mangaService: MangaService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addManga(manga: DatumManga){
    this.mangaAngularService.addManga(manga.id!).subscribe(() => {
      this.toastr.success("You have added " + manga.title);
    })
  }

  isMangaAlreadyAdded(mangaId: ObjectId): boolean{
    this.mangaService.apiMangaMangaAlreadyAddedGet(mangaId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
