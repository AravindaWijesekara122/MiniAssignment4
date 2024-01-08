import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovieDetails } from '../models/movie-details.model';
import { ShowDetails } from '../models/show-details.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:7163/api/admin';

  constructor(private http: HttpClient) { }

  addMovie(movie: MovieDetails): Observable<MovieDetails> {
    return this.http.post<MovieDetails>(`${this.apiUrl}/addmovie`, movie);
  }

  getCurrentShows(): Observable<ShowDetails[]> {
    return this.http.get<ShowDetails[]>(`${this.apiUrl}/currentshows`);
  }
}

