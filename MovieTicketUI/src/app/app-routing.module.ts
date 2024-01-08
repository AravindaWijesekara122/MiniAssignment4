import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { CurrentShowsComponent } from './components/current-shows/current-shows.component';

const routes: Routes = [
  { path: 'add-movie', component: MovieFormComponent },
  { path: 'current-shows', component: CurrentShowsComponent },
  // Add more routes as needed
  { path: '', redirectTo: '/current-shows', pathMatch: 'full' }, // Default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
