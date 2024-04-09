import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { MangaService } from "api/manga.service";
import { MoviesService } from "api/movies.service";
import { DatumManga } from "model/datumManga";
import { Movie } from "model/movie";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class MangaDetailedResolver implements Resolve<DatumManga>{

    constructor(private mangaService: MangaService){

    }

    resolve(route: ActivatedRouteSnapshot): Observable<DatumManga>{
        return this.mangaService.getManga(route.paramMap.get('title')!);
    }

}