import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { CurrentShowsComponent } from './components/current-shows/current-shows.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { ShowListComponent } from './components/show-list/show-list.component';

const routes: Routes = [
  { path: 'add-movie', component: MovieFormComponent },
  { path: 'current-shows', component: CurrentShowsComponent },
  { path: 'selected-movies', component: MovieListComponent},
  { path: 'show-list/:movieId', component: ShowListComponent},
  { path: '', redirectTo: '/current-shows', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
