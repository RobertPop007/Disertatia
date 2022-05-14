import { Component, Input, OnInit } from '@angular/core';
import { TvShowsService } from 'api/tvShows.service';
import { TvShow } from 'model/tvShow';
import { ToastrService } from 'ngx-toastr';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-tv-show-card',
  templateUrl: './tv-show-card.component.html',
  styleUrls: ['./tv-show-card.component.scss']
})
export class TvShowCardComponent implements OnInit {

  @Input() tvShow!: TvShow;
  
  constructor(private tvShowAngularService: TvShowsAngularService,
    private tvShowService: TvShowsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addTvShow(tvShow: TvShow){
    this.tvShowAngularService.addTvShow(tvShow.id!).subscribe(() => {
      this.toastr.success("You have added " + tvShow.fullTitle);
    })
  }

  isTvShowAlreadyAdded(tvShowId: string): boolean{
    this.tvShowService.apiTvShowsTvShowAlreadyAddedGet(tvShowId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
