import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MangaService } from 'api/manga.service';
import { DatumManga } from 'model/datumManga';
import { map, of, take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MangaParams } from '../_models/mangaParams';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';
import { ObjectId } from 'model/objectId';

@Injectable({
  providedIn: 'root'
})
export class MangaAngularService {

  baseUrl = environment.apiUrl;
  manga!: DatumManga;
  mangaParams!: MangaParams;
  user!: User;
  mangaCache = new Map();
  userParams!: UserParams;
  searchedManga = "";

  constructor(private http: HttpClient, private accountService: AccountService, private mangaService: MangaService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: User) => {
      this.user = user;
      this.mangaParams = new MangaParams(user, this.searchedManga);
    })
  }

  getMangaParams(){
    return this.mangaParams;
  }

  setMangaParams(params: MangaParams){
    this.mangaParams = params;
  }

   resetMangaParams(){
    this.searchedManga = "";
    this.mangaParams = new MangaParams(this.user, this.searchedManga);
    return this.mangaParams;
   }

   getMangas(mangaParams: MangaParams) {
    var response = this.mangaCache.get(Object.values(mangaParams).join('-'));

    if(response){
      return of(response);
    }

    let params = getPaginationHeaders(mangaParams.pageNumber, mangaParams.pageSize);

    params = params.append('searchedManga', mangaParams.searchedManga);
    params = params.append('orderBy', mangaParams.orderBy);

    return getPaginatedResult<DatumManga[]>(this.baseUrl + 'Manga/GetAllmangas', params, this.http).
      pipe(map(response => {
        this.mangaCache.set(Object.values(mangaParams).join('-'), response);
        return response;
      }))
  }

  getManga(title: string) {
    const manga = [...this.mangaCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((manga : DatumManga) => manga.title === title);

    if(manga){
      return of(manga);
    }

    return this.http.get<DatumManga>(this.baseUrl + "Manga/" + title);
  }

  addManga(mangaId: ObjectId){
    return this.mangaService.apiMangaAddMangaMangaIdPost(mangaId);
  }

  getMangasForUser(predicate: string, pageNumber: number, pageSize: number){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('predicate', predicate);

    return getPaginatedResult<Partial<DatumManga[]>>(this.baseUrl + 'Manga/GetMangasFor', params, this.http);
  }

  deleteMangaForUser(mangaId: ObjectId){
    return this.http.delete(this.baseUrl + 'Manga/' + mangaId);
  }
}
