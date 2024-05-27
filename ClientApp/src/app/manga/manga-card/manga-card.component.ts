import { Component, Input, OnInit } from '@angular/core';
import { MangaService } from 'api/manga.service';
import { DatumManga } from 'model/datumManga';
import { ObjectId } from 'model/objectId';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { MangaCard } from 'src/app/_models/mangaCard';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';

@Component({
  selector: 'app-manga-card',
  templateUrl: './manga-card.component.html',
  styleUrls: ['./manga-card.component.scss']
})
export class MangaCardComponent implements OnInit {

  @Input() manga!: MangaCard;
  res!: boolean;
  
  constructor(private mangaAngularService: MangaAngularService,
    private mangaService: MangaService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.mangaService.apiMangaMangaAlreadyAddedGet(this.manga.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addManga(manga: DatumManga){
    this.mangaAngularService.addManga(manga.id!).subscribe(() => {
      this.toastr.success("You have added " + manga.title);
    })
    
    this.res = true;
  }

  deleteManga(manga: DatumManga){
    this.mangaAngularService.deleteMangaForUser(manga.id!).subscribe(() => {
      this.toastr.success("You have deleted " + manga.title);
    })

    this.res = false;
  }

  isMangaAlreadyAdded(mangaId: ObjectId): boolean{
    this.mangaService.apiMangaMangaAlreadyAddedGet(mangaId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
