import { DOCUMENT } from '@angular/common';
import { Component, HostListener, Inject, OnInit, Renderer2, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { DarkModeService } from 'angular-dark-mode';
import { MoviesService } from 'api/movies.service';
import { Movie } from 'model/movie';
import { MovieItem } from 'model/movieItem';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Theme } from 'src/app/app.component';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { MoviesAngularService } from 'src/app/_services/movies_angular.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm!: NgForm;
  member!: Member;
  user!: User;
  theme: Theme = 'light-theme';
  watchedMovies?: Movie[];
  predicate = 'added';
  pageNumber = 1;
  isDarkMode!: boolean;
  pageSize = 5;
  pagination!: Pagination;
  currentMode: string = this.isDarkMode ? "Light mode" : "Dark mode";

  checked = false;
  disabled = false;
  
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if(this.editForm.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService,
              private memberService: MembersService,
              private moviesService: MoviesService,
              private toastr: ToastrService,
              private darkModeService: DarkModeService,
              private renderer: Renderer2,
              @Inject(DOCUMENT) private document: Document) {
                this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
               }

  ngOnInit(): void {
    this.loadMember();
    this.updateWatchList();

    this.isDarkMode = (this.currentMode == "Dark mode") ? true : false;

    if(this.isDarkMode === true)
    {
      this.darkModeService.enable();
    }

    this.initializeTheme();
  }

  initializeTheme = (): void =>
      this.renderer.addClass(this.document.body, this.theme);

  switchTheme(){
    this.document.body.classList.replace(
      this.theme, 
      this.theme === 'light-theme' 
      ? (this.theme = 'dark-theme') 
      : (this.theme = 'light-theme'))

      this.setDisplayMode(this.theme);
  }

  setDisplayMode(mode: string) {
    localStorage.setItem("currentMode", mode);
    this.currentMode = mode;
  }


  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    })
  }

  updateMember(){
    this.memberService.updateMember(this.member).subscribe(() => {
      this.toastr.success('Profile updated successfully');
      this.editForm.reset(this.member);
    })
  }

  updateWatchList(){
    this.moviesService.apiMoviesGetMoviesForUsernameGet(this.user.username).subscribe(response => {
      this.watchedMovies = response;
    })
  }
}
