import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DatumManga } from 'model/datumManga';
import { ToastrService } from 'ngx-toastr';
import { MangaAngularService } from 'src/app/_services/manga_angular.service';

@Component({
  selector: 'app-manga-card-added',
  templateUrl: './manga-card-added.component.html',
  styleUrls: ['./manga-card-added.component.scss']
})
export class MangaCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() manga!: DatumManga;
  mangaAlreadyAdded!: boolean;
  
  constructor(private mangaAngularService: MangaAngularService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  deleteMangaForUser(manga: DatumManga){
    this.mangaAngularService.deleteMangaForUser(manga.id!).subscribe(() => {
      this.toastr.success("You have deleted " + manga.title);

      this.deleteEvent.emit("This value is coming from child");
    });
  }

}
