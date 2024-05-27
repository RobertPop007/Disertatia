import { Component, Input, OnInit } from '@angular/core';
import { GameService } from 'api/game.service';
import { Game } from 'model/game';
import { ObjectId } from 'model/objectId';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { GameCard } from 'src/app/_models/gameCard';
import { GamesAngularService } from 'src/app/_services/games_angular.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit {

  @Input() game!: GameCard;
  res!: boolean;
  
  constructor(private gameAngularService: GamesAngularService,
    private gameService: GameService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.gameService.apiGameGameAlreadyAddedGet(this.game.id!).pipe(take(1)).subscribe(res => {
      this.res = res;
    })
  }

  addGame(game: Game){
    this.gameAngularService.addGame(game.id!).subscribe(() => {
      this.toastr.success("You have added " + game.name);
    })

    this.res = true;
  }

  deleteGame(game: Game){
    this.gameAngularService.deleteGameForUser(game.id!).subscribe(() => {
      this.toastr.success("You have deleted " + game.name);
    })

    this.res = false;
  }

  isGameAlreadyAdded(gameId: ObjectId): boolean{
    this.gameService.apiGameGameAlreadyAddedGet(gameId).subscribe((response) => {
      return response;
    })
    return false;
  }

}
