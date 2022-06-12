import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public acccountService: AccountService,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login(){
    var username = (<HTMLInputElement>document.getElementById("username")).value;
    var password = (<HTMLInputElement>document.getElementById("password")).value;

    if(username !== "" && password !== ""){
      this.acccountService.login(this.model).subscribe(response => {
        
        this.router.navigateByUrl('/members').then(() => {
          //window.location.reload();
        });
        console.log(response);
        
        this.toastr.success("Login successfully!");
      });
    }
    else{
      this.toastr.info("You have to type in your data!")
    }
  }

  logout(){
    this.acccountService.logout();
    this.router.navigateByUrl('/');
  }
}
