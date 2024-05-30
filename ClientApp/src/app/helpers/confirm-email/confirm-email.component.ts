import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'api/account.service';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.scss'],
  providers: [
    AccountService
  ]
})
export class ConfirmEmailComponent implements OnInit {

  userId!: string;
  token!: string;
  encodedToken!: string;

  constructor(private route: ActivatedRoute,
    private accountService: AccountService) { 
      this.route.queryParams.subscribe(params => {
        this.userId = params['userId'];
        this.token = params['token'];

        console.log(this.token)

        this.encodedToken = encodeURIComponent(this.token);
      });
    }

  ngOnInit(): void {
    this.accountService.apiAccountConfirmEmailPost(this.userId, this.token).subscribe();
  }

}
