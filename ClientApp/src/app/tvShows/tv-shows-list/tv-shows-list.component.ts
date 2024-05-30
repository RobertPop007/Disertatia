import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/_models/pagination';
import { TvShowCard } from 'src/app/_models/tvShowCard';
import { User } from 'src/app/_models/user';
import { TvShowParams } from 'src/app/_models/tvShowParams';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';
import { TvShowsService } from 'api/tvShows.service';

@Component({
  selector: 'app-tv-shows-list',
  templateUrl: './tv-shows-list.component.html',
  styleUrls: ['./tv-shows-list.component.css'],
  providers: [TvShowsAngularService, TvShowsService]
})
export class TvShowsListComponent implements OnInit {
  tvShows!: TvShowCard[];
  pagination!: Pagination;
  tvShowParams!: TvShowParams;
  user!: User;
  p?: string | number | undefined = 1;
  searchedTvShow = "";

  constructor(private tvShowsAngularService: TvShowsAngularService) {
    this.tvShowParams = this.tvShowsAngularService.getTvShowParams();
   }

  ngOnInit(): void {
    this.loadTvShows();
  }

  loadTvShows(){
    console.log(this.tvShowParams)
    this.tvShowsAngularService.setTvShowParams(this.tvShowParams);

    this.tvShowsAngularService.getTvShows(this.tvShowParams).subscribe(response => {
      this.tvShows = response.result!;
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.tvShowParams = this.tvShowsAngularService.resetTvShowParams();
    this.loadTvShows();
  }

  pageChanged(event: any){
    this.tvShowParams.pageNumber = event.page;
    this.tvShowsAngularService.setTvShowParams(this.tvShowParams);
    this.loadTvShows();
  }

}
