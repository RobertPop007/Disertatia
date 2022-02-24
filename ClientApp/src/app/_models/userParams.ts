import { User } from "./user";

export class UserParams{
    gender!: string;
    username!: string;
    pageNumber = 1;
    pageSize = 5;
    searchedUsername!: string;
    orderBy = "username";

    constructor(user: User, searchedUsername: string){
        this.username = user.username;
        this.searchedUsername = searchedUsername;
    }
}