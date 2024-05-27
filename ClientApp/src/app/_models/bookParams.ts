import { User } from "./user";

export class BookParams{
    username!: string;
    pageNumber = 1;
    pageSize = 72;
    searchedBook!: string;
    orderBy = "ratingsCount";

    constructor(user: User, searchedBook: string){
        this.username = user.username;
        this.searchedBook = searchedBook;
    }
}