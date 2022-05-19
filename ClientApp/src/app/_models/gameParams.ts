import { Movie } from "./movie";
import { User } from "./user";

export class GameParams{
    username!: string;
    pageNumber = 1;
    pageSize = 20;
    searchedGame!: string;
    orderBy = "rating";

    constructor(user: User, searchedGame: string){
        this.username = user.username;
        this.searchedGame = searchedGame;
    }
}