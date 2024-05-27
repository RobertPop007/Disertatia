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
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MovieCardAddedComponent } from './movies/movie-card-added/movie-card-added.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
import { SafePipe } from './_pipes/safe.pipe';
import { IvyCarouselModule } from 'angular-responsive-carousel';
import { FooterComponent } from './footer/footer.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgxFixedFooterModule } from 'ngx-fixed-footer';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { ScrollToTopComponent } from './scroll-to-top/scroll-to-top.component';
import { TvShowDetailComponent } from './tvShows/tv-show-detail/tv-show-detail.component';
import { TvShowCardAddedComponent } from './tvShows/tv-show-card-added/tv-show-card-added.component';
import { TvShowCardComponent } from './tvShows/tv-show-card/tv-show-card.component';
import { AnimeCardComponent } from './anime/anime-card/anime-card.component';
import { AnimeCardAddedComponent } from './anime/anime-card-added/anime-card-added.component';
import { AnimeDetailComponent } from './anime/anime-detail/anime-detail.component';
import { MangaCardComponent } from './manga/manga-card/manga-card.component';
import { MangaCardAddedComponent } from './manga/manga-card-added/manga-card-added.component';
import { GameCardAddedComponent } from './games/game-card-added/game-card-added.component';
import { GameCardComponent } from './games/game-card/game-card.component';
import { GameListComponent } from './games/game-list/game-list.component';
import { GameDetailComponent } from './games/game-detail/game-detail.component';
import { MangaDetailComponent } from './manga/manga-detail/manga-detail.component';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import {MatRadioModule} from '@angular/material/radio';
import { MemberCardAddedComponent } from './members/member-card-added/member-card-added.component';
import { AnimeService } from 'api/anime.service';
import { MangaService } from 'api/manga.service';
import { MoviesService } from 'api/movies.service';
import { TvShowsService } from 'api/tvShows.service';
import { GameService } from 'api/game.service';
import { PaginationComponent } from './_pagination/pagination/pagination.component';
import { StarRatingComponent } from './helpers/star-rating/star-rating.component';
import { ConfirmEmailComponent } from './helpers/confirm-email/confirm-email.component';
import { BookCardComponent } from './books/book-card/book-card.component';
import { BookCardAddedComponent } from './books/book-card-added/book-card-added.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { BooksService } from 'api/books.service';

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
    MovieCardComponent,
    MovieDetailComponent,
    MovieCardAddedComponent,
    SafePipe,
    FooterComponent,
    ScrollToTopComponent,
    TvShowDetailComponent,
    TvShowCardAddedComponent,
    TvShowCardComponent,
    AnimeCardComponent,
    AnimeCardAddedComponent,
    AnimeDetailComponent,
    MangaCardComponent,
    MangaCardAddedComponent,
    MangaDetailComponent,
    GameCardAddedComponent,
    GameCardComponent,
    GameListComponent,
    GameDetailComponent,
    ConfirmDialogComponent,
    MemberCardAddedComponent,
    PaginationComponent,
    StarRatingComponent,
    ConfirmEmailComponent,
    BookCardComponent,
    BookCardAddedComponent,
    BookDetailComponent
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
    BsDatepickerModule.forRoot(),
    MatSlideToggleModule,
    NgbModule,
    MdbCheckboxModule,
    IvyCarouselModule,
    NgxPaginationModule,
    NgxFixedFooterModule,
    CarouselModule,
    MdbCheckboxModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
    MatRadioModule
  ],
  entryComponents: [
    ConfirmDialogComponent
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}, //multi: true inseamna ca adauga interceptorii astia la aia care sunt deja, nu ii inlocuieste
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    AnimeService,
    MangaService,
    MoviesService,
    TvShowsService,
    GameService,
    BooksService
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }