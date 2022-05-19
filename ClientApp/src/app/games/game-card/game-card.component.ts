import { Component, Input, OnInit } from '@angular/core';
import { GameService } from 'api/game.service';
import { Game } from 'model/game';
import { ToastrService } from 'ngx-toastr';
import { GameCard } from 'src/app/_models/gameCard';
import { GamesAngularService } from 'src/app/_services/games_angular.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit {

  @Input() game!: GameCard;
  
  constructor(private gameAngularService: GamesAngularService,
    private gameService: GameService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  addGame(game: Game){
    this.gameAngularService.addGame(game.id!).subscribe(() => {
      this.toastr.success("You have added " + game.name);
    })
  }

  isGameAlreadyAdded(gameId: number): boolean{
    this.gameService.apiGameGameAlreadyAddedGet(gameId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
