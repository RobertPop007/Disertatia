import { Component, Input, OnInit } from '@angular/core';
import { TvShowsService } from 'api/tvShows.service';
import { ObjectId } from 'model/objectId';
import { TvShow } from 'model/tvShow';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { TvShowCard } from 'src/app/_models/tvShowCard';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-tv-show-card',
  templateUrl: './tv-show-card.component.html',
  styleUrls: ['./tv-show-card.component.scss']
})
export class TvShowCardComponent implements OnInit {

  @Input() tvShow!: TvShowCard;
  res!: boolean;
  
  constructor(private tvShowAngularService: TvShowsAngularService,
    private tvShowService: TvShowsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.tvShowService.apiTvShowsTvShowAlreadyAddedGet(this.tvShow.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addTvShow(tvShow: TvShow){
    this.tvShowAngularService.addTvShow(tvShow.id!).subscribe(() => {
      this.toastr.success("You have added " + tvShow.name);
    })

    this.res = true;
  }

  deleteTvShow(tvShow: TvShow){
    this.tvShowAngularService.deleteTvShowForUser(tvShow.id!).subscribe(() => {
      this.toastr.success("You have deleted " + tvShow.name);
    })

    this.res = false;
  }

  isTvShowAlreadyAdded(tvShowId: ObjectId): boolean{
    this.tvShowService.apiTvShowsTvShowAlreadyAddedGet(tvShowId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
