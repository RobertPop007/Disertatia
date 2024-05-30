import { User } from "./user";

export class TvShowParams{
    username!: string;
    pageNumber = 1;
    pageSize = 72;
    searchedTvShow!: string;
    orderBy = "";

    constructor(user: User, searchedTvShow: string){
        this.username = user.username;
        this.searchedTvShow = searchedTvShow;
    }
}