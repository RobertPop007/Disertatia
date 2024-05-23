import { Component, Input, OnInit } from '@angular/core';
import { TvShowsService } from 'api/tvShows.service';
import { ObjectId } from 'model/objectId';
import { TvShow } from 'model/tvShow';
import { ToastrService } from 'ngx-toastr';
import { TvShowCard } from 'src/app/_models/tvShowCard';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-tv-show-card',
  templateUrl: './tv-show-card.component.html',
  styleUrls: ['./tv-show-card.component.scss']
})
export class TvShowCardComponent implements OnInit {

  @Input() tvShow!: TvShowCard;
  
  constructor(private tvShowAngularService: TvShowsAngularService,
    private tvShowService: TvShowsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addTvShow(tvShow: TvShow){
    this.tvShowAngularService.addTvShow(tvShow.tvShowId!).subscribe(() => {
      this.toastr.success("You have added " + tvShow.name);
    })
  }

  isTvShowAlreadyAdded(tvShowId: ObjectId): boolean{
    this.tvShowService.apiTvShowsTvShowAlreadyAddedGet(tvShowId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
