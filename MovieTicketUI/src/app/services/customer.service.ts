// customer.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { formatDate } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7163/api/customer';

  constructor(private http: HttpClient) {}

  getMoviesByDate(selectedDate: Date): Observable<any> {
    const formattedDate = formatDate(selectedDate, 'yyyy-MM-dd', 'en-US');
    return this.http.get<any>(`${this.apiUrl}/selected-movies?selectedDate=${formattedDate}`);
  }

  getShowDetails(movieId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/shows/${movieId}`);
  }
}
