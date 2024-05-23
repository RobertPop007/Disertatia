import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { PresenceService } from 'src/app/_services/presence.service';

@Component({
  selector: 'app-member-card-added',
  templateUrl: './member-card-added.component.html',
  styleUrls: ['./member-card-added.component.scss']
})
export class MemberCardAddedComponent implements OnInit {

  @Input() member!: Member;
  
  constructor(private memberService: MembersService,
    private toastr: ToastrService,
    public presence: PresenceService,
    private route: ActivatedRoute, 
    private router: Router) {
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;

      
     }

  ngOnInit(): void {
    console.log(this.member)
  }

  removeFriend(member: Member){
    this.memberService.removeFriend(member.userName).subscribe(() => {
      this.toastr.success('You have removed ' + member.userName);
    })
  }

}
