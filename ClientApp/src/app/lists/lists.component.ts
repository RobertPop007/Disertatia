import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { Pagination } from '../_models/pagination';
import { MembersService } from '../_services/members.service';
import { FriendsDto } from 'model/friendsDto';
import { FriendRequest } from 'model/friendRequest';
import { FriendsRequestsDto } from 'model/friendsRequestsDto';
import { ToastrService } from 'ngx-toastr';
import { AppUser } from 'model/appUser';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {

  members!: Partial<Member[]>;
  friendRequests!: Partial<FriendsRequestsDto[]>;
  predicate = 'friends';
  pageNumber = 1;
  pageSize = 5;
  pagination!: Pagination;
  member!: Member; 

  constructor(private memberService: MembersService,
              private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.loadFriends();
    this.loadFriendsRequests();
    
    console.log(this.members);
  }

  loadFriends(){
    this.memberService.getFriends(this.predicate, this.pageNumber, this.pageSize).subscribe(response => {
      this.members = response.result!;
      this.pagination = response.pagination;
    })
  }

  loadFriendsRequests(){
    this.predicate = "friendsRequests";
    this.memberService.getFriendRequests(this.predicate, this.pageNumber, this.pageSize).subscribe(response => {
      this.friendRequests = response.result!;
      console.log(this.friendRequests);
      this.pagination = response.pagination;
    })
  }

  acceptFriendRequest(username: string){
    this.memberService.addFriend(username).subscribe((response: AppUser) => {
      const newFriend: Member = {
        photoUrl: response.photos?.url!,
        userName: response.userName!,
        knownAs: response.knownAs!
      }

      const index = this.friendRequests.findIndex(request => response.userName === username);
      if (index !== -1) {
        // Remove the friend request from the array
        this.friendRequests.splice(index, 1);
      }

      this.members.push(newFriend)
      this.toastr.success("You have added " + username + " as your friend!")
    })
  }

  declineFriendRequest(username: string){
    this.memberService.declineFriendRequest(username).subscribe(response => {
      this.toastr.success("You have declined " + username + ",s friend request!")
    })
  }

  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadFriends();
  }
}
