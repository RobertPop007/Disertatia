import { Component, Inject, OnInit, Renderer2 } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';
import { PresenceService } from './_services/presence.service';
import { Observable } from 'rxjs';
import { DarkModeService } from 'angular-dark-mode';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  theme: Theme = 'light-theme';
  users: any;
  isDarkMode!: boolean;
  darkMode$: Observable<boolean> = this.darkModeService.darkMode$;
  currentMode: string = this.isDarkMode ? "Light mode" : "Dark mode";

  constructor(private accountService: AccountService, 
              private presence: PresenceService,
              private darkModeService: DarkModeService,
              @Inject(DOCUMENT) private document: Document,
              private renderer: Renderer2) {}

  ngOnInit() {
    this.setCurrentUser();
    
    this.isDarkMode = (this.currentMode == "Dark mode") ? true : false;

    if(this.isDarkMode === true)
    {
      this.darkModeService.enable();
    }

    this.initializeTheme();
  }

  switchTheme(){
    this.document.body.classList.replace(
      this.theme, 
      this.theme === 'light-theme' 
      ? (this.theme = 'dark-theme') 
      : (this.theme = 'light-theme'))

      this.setDisplayMode(this.theme);
  }

  initializeTheme = (): void =>
      this.renderer.addClass(this.document.body, this.theme);

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
    
    if(user.username !== undefined){ //if(user) - asa era inainte
      if(user.username !== undefined) //pentru ca la refresh cand nu esti logat, te loga instant
        this.accountService.setCurrentUser(user);

      this.presence.createHubConnection(user);
    }

    
  }
}

export type Theme = 'light-theme' | 'dark-theme';