import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Game } from 'model/game';
import { ToastrService } from 'ngx-toastr';
import { GamesAngularService } from 'src/app/_services/games_angular.service';

@Component({
  selector: 'app-game-card-added',
  templateUrl: './game-card-added.component.html',
  styleUrls: ['./game-card-added.component.scss']
})
export class GameCardAddedComponent implements OnInit {

  @Output()
  deleteEvent: EventEmitter<string> = new EventEmitter<string>();

  @Input() game!: Game;
  gameAlreadyAdded!: boolean;
  
  constructor(private gameAngularService: GamesAngularService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  deleteGameForUser(game: Game){
    this.gameAngularService.deleteGameForUser(game.id!).subscribe(() => {
      this.toastr.success("You have deleted " + game.name);

      this.deleteEvent.emit("This value is coming from child");
    });
  }

}
