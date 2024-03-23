import { Component, OnInit } from '@angular/core';
import { GameCard } from 'src/app/_models/gameCard';
import { GameParams } from 'src/app/_models/gameParams';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { GamesAngularService } from 'src/app/_services/games_angular.service';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.scss']
})
export class GameListComponent implements OnInit {

  games!: GameCard[];
  pagination!: Pagination;
  gameParams!: GameParams;
  user!: User;
  p?: string | number | undefined = 1;
  searchedGame = "";

  constructor(private gameAngularService: GamesAngularService) {
    this.gameParams = this.gameAngularService.getGameParams();
   }

  ngOnInit(): void {
    this.loadGames();
  }

  loadGames(){
    this.gameAngularService.setGameParams(this.gameParams);

    this.gameAngularService.getGames(this.gameParams).subscribe(response => {
      this.games = response.result!;
      this.pagination = response.pagination!;
    })
  }

  resetFilters(){ 
    this.gameParams = this.gameAngularService.resetGameParams();
    this.loadGames();
  }

  pageChanged(event: any){
    this.gameParams.pageNumber = event.page;
    this.gameAngularService.setGameParams(this.gameParams);
    this.loadGames();
  }


}
