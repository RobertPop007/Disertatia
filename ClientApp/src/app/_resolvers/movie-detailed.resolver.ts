import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { MoviesService } from "api/movies.service";
import { Movie } from "model/movie";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class MovieDetailedResolver implements Resolve<Movie>{

    constructor(private movieService: MoviesService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<Movie>{
        return this.movieService.getMovie(route.paramMap.get('title')!);
    }

}