import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { GameService } from "api/game.service";
import { MoviesService } from "api/movies.service";
import { Game } from "model/game";
import { Movie } from "model/movie";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class GameDetailedResolver implements Resolve<Game>{

    constructor(private gameService: GameService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<Game>{
        return this.gameService.getGame(route.paramMap.get('name')!);
    }

}