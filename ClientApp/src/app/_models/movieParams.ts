import { Movie } from "./movie";
import { User } from "./user";

export class MovieParams{
    username!: string;
    pageNumber = 1;
    pageSize = 20;
    searchedMovie!: string;
    orderBy = "imdbRating";

    constructor(user: User, searchedMovie: string){
        this.username = user.username;
        this.searchedMovie = searchedMovie;
    }
}