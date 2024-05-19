import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AnimeDetailComponent } from './anime/anime-detail/anime-detail.component';
import { AnimeListComponent } from './anime/anime-list/anime-list.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { GameDetailComponent } from './games/game-detail/game-detail.component';
import { GameListComponent } from './games/game-list/game-list.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MangaDetailComponent } from './manga/manga-detail/manga-detail.component';
import { MangaListComponent } from './manga/manga-list/manga-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MusicListComponent } from './music/music-list/music-list.component';
import { TvShowDetailComponent } from './tvShows/tv-show-detail/tv-show-detail.component';
import { TvShowsListComponent } from './tvShows/tv-shows-list/tv-shows-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { AnimeDetailedResolver } from './_resolvers/anime-detailed.resolver';
import { GameDetailedResolver } from './_resolvers/game-detailed.resolver';
import { MangaDetailedResolver } from './_resolvers/manga-detailed.resolver';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { MovieDetailedResolver } from './_resolvers/movie-detailed.resolver';
import { TvShowDetailedResolver } from './_resolvers/tvShow-detailed.resolver';
import { ConfirmEmailComponent } from './helpers/confirm-email/confirm-email.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'confirmEmail', component: ConfirmEmailComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'members/:username', component: MemberDetailComponent, resolve: {member: MemberDetailedResolver}},
      {path: 'movies/:title', component: MovieDetailComponent, resolve: {movie: MovieDetailedResolver}},
      {path: 'tvShows/:title', component: TvShowDetailComponent, resolve: {tvShow: TvShowDetailedResolver}},
      {path: 'anime/:title', component: AnimeDetailComponent, resolve: {anime: AnimeDetailedResolver}},
      {path: 'manga/:title', component: MangaDetailComponent, resolve: {manga: MangaDetailedResolver}},
      {path: 'games/:name', component: GameDetailComponent, resolve: {game: GameDetailedResolver}},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},
      {path: 'movies', component: MoviesListComponent},
      {path: 'games', component: GameListComponent},
      {path: 'tvShows', component: TvShowsListComponent},
      {path: 'books', component: BooksListComponent},
      {path: 'anime', component: AnimeListComponent},
      {path: 'manga', component: MangaListComponent},
      {path: 'music', component: MusicListComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]}
    ]
  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: 'contact', component: ContactPageComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
