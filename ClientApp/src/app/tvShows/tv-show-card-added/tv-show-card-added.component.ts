import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TvShowsService } from 'api/tvShows.service';
import { TvShow } from 'model/tvShow';
import { ToastrService } from 'ngx-toastr';
import { TvShowsAngularService } from 'src/app/_services/tvShows_angular.service';

@Component({
  selector: 'app-tv-show-card-added',
  templateUrl: './tv-show-card-added.component.html',
  styleUrls: ['./tv-show-card-added.component.scss']
})
export class TvShowCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() tvShow!: TvShow;
  tvShowAlreadyAdded!: boolean;
  
  constructor(private tvShowAngularService: TvShowsAngularService,
    private tvShowService: TvShowsService,
    private toastr: ToastrService ) {}

  ngOnInit(): void {
  }

  deleteTvShowForUser(tvShow: TvShow){
    this.tvShowAngularService.deleteTvShowForUser(tvShow.id!).subscribe(() => {
      this.toastr.success("You have deleted " + tvShow.title);

      this.deleteEvent.emit("This value is coming from child");
    });
  }

}
