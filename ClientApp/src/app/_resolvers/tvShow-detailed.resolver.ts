import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { TvShowsService } from "api/api";
import { MoviesService } from "api/movies.service";
import { Movie } from "model/movie";
import { TvShow } from "model/tvShow";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class TvShowDetailedResolver implements Resolve<TvShow>{

    constructor(private tvShowService: TvShowsService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<TvShow>{
        return this.tvShowService.getTvShow(route.paramMap.get('fullTitle')!);
    }

}