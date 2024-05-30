import { Movie } from "./movie";
import { User } from "./user";

export class AnimeParams{
    username!: string;
    pageNumber = 1;
    pageSize = 72;
    searchedAnime!: string;
    orderBy = "";

    constructor(user: User, searchedAnime: string){
        this.username = user.username;
        this.searchedAnime = searchedAnime;
    }
}