import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AccordionModule } from 'ngx-bootstrap/accordion' 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { PhotoEditorComponent } from './members/photo-editor/photo-editor.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MemberMessagesComponent } from './members/member-messages/member-messages.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { RolesModalComponent } from './_modals/roles-modal/roles-modal.component';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { AnimeListComponent } from './anime/anime-list/anime-list.component';
import { TvShowsListComponent } from './tvShows/tv-shows-list/tv-shows-list.component';
import { MangaListComponent } from './manga/manga-list/manga-list.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { MusicListComponent } from './music/music-list/music-list.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { MovieCardComponent } from './movies/movie-card/movie-card.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailComponent,
    ListsComponent,
    MessagesComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    MemberCardComponent,
    MemberEditComponent,
    PhotoEditorComponent,
    TextInputComponent,
    DateInputComponent,
    MemberMessagesComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    PhotoManagementComponent,
    RolesModalComponent,
    MoviesListComponent,
    AnimeListComponent,
    TvShowsListComponent,
    MangaListComponent,
    BooksListComponent,
    MusicListComponent,
    ContactPageComponent,
    MovieCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AccordionModule.forRoot(),
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}, //multi: true inseamna ca adauga interceptorii astia la aia care sunt deja, nu ii inlocuieste
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
