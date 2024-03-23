import { User } from "./user";

export class TvShowParams{
    username!: string;
    pageNumber = 1;
    pageSize = 20;
    searchedTvShow!: string;
    orderBy = "imdbRating";

    constructor(user: User, searchedTvShow: string){
        this.username = user.username;
        this.searchedTvShow = searchedTvShow;
    }
}