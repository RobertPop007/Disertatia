import { ConsoleLogger } from '@angular/compiler-cli/private/localize';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { PresenceService } from 'src/app/_services/presence.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() member!: Member;
  isFriend!: boolean;
  
  constructor(private memberService: MembersService,
              private toastr: ToastrService,
              public presence: PresenceService) { }

  ngOnInit(): void {
    this.isUserFriend(this.member);
    console.log(this.isFriend)
  }

  sendFriendRequest(member: Member){
    this.memberService.sendFriendRequest(member.userName).subscribe(() => {
      this.toastr.success('Your friend request has been sent to ' + member.userName);
    })
  }

  removeFriend(member: Member){
    this.memberService.removeFriend(member.userName).subscribe(() => {
      this.toastr.success('You have removed ' + member.userName);
    })
  }

  isUserFriend(member: Member){
    this.memberService.checkFriendship(member.userName).subscribe((result: boolean) => {
      this.isFriend = result;
    })
  }
}
