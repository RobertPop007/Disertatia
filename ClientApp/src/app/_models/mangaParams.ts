import { Movie } from "./movie";
import { User } from "./user";

export class MangaParams{
    username!: string;
    pageNumber = 1;
    pageSize = 20;
    searchedManga!: string;
    orderBy = "score";

    constructor(user: User, searchedManga: string){
        this.username = user.username;
        this.searchedManga = searchedManga;
    }
}