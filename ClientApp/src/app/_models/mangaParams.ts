import { Movie } from "./movie";
import { User } from "./user";

export class MangaParams{
    username!: string;
    pageNumber = 1;
    pageSize = 72;
    searchedManga!: string;
    orderBy = "";

    constructor(user: User, searchedManga: string){
        this.username = user.username;
        this.searchedManga = searchedManga;
    }
}