// movie-list.component.ts
import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {
  selectedDate: Date = new Date(); // Initialize with the default date format

  movies: any[] = [];

  constructor(private customerService: CustomerService, private router: Router) {}

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies() {
    this.customerService.getMoviesByDate(this.selectedDate)
      .subscribe((data) => {
        console.log(this.selectedDate);
        console.log(data);
        this.movies = data;
      },
      (error) => {
        console.error('Error fetching movies:', error);
      }
    );
  }

  navigateToShowDetails(movieId: number) {
    this.router.navigate(['/show-list', movieId]);
  }
}

