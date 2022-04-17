import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';
import { PresenceService } from './_services/presence.service';
import { Observable } from 'rxjs';
import { DarkModeService } from 'angular-dark-mode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The dating app';
  users: any;
  isDarkMode!: boolean;
  darkMode$: Observable<boolean> = this.darkModeService.darkMode$;
  currentMode: string = this.isDarkMode ? "Light mode" : "Dark mode";

  constructor(private accountService: AccountService, 
              private presence: PresenceService,
              private darkModeService: DarkModeService) {}

  ngOnInit() {
    this.setCurrentUser();

    this.currentMode = localStorage.getItem("currentMode")!;
    this.isDarkMode = (this.currentMode == "Dark mode") ? true : false;

    if(this.isDarkMode == true)
    {
      this.darkModeService.enable();
    }
  }

  setDisplayMode(mode: string) {
    localStorage.setItem("currentMode", mode);
    
    this.currentMode = mode;
  }

  onToggle(): void {
    this.setDisplayMode(this.isDarkMode ? "Light mode" : "Dark mode");
    this.darkModeService.toggle();
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user') || '{}');

    if(user){
      if(user.username || user.token) //pentru ca la refresh cand nu esti logat, te loga instant
        this.accountService.setCurrentUser(user);
      
      this.presence.createHubConnection(user);
    }

    
  }
}