import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { AnimeService } from "api/anime.service";
import { MoviesService } from "api/movies.service";
import { Datum } from "model/datum";
import { Movie } from "model/movie";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class AnimeDetailedResolver implements Resolve<Datum>{

    constructor(private animeService: AnimeService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<Datum>{
        return this.animeService.getAnime(route.paramMap.get('title')!);
    }

}