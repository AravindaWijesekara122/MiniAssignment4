import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminService } from '../../services/admin.service';
import { MovieDetails } from 'src/app/models/movie-details.model';

@Component({
  selector: 'app-movie-form',
  templateUrl: './movie-form.component.html',
  styleUrls: ['./movie-form.component.css']
})
export class MovieFormComponent implements OnInit {
  movieForm!: FormGroup;

  constructor(private fb: FormBuilder, private adminService: AdminService) { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.movieForm = this.fb.group({
      movieName: ['', Validators.required],
      genre: ['', Validators.required],
      director: ['', Validators.required],
      description: ['', Validators.required],
      screenNumber: ['', Validators.required],
      timings: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      noOfSeatsAvailable: ['', [Validators.required, Validators.min(1)]],
      perPersonPrice: ['', [Validators.required, Validators.min(0)]],
    });
  }

  onSubmit(): void {
    if (this.movieForm.valid) {
      const movieDetails = this.movieForm.value as MovieDetails;
      this.adminService.addMovie(movieDetails).subscribe(
        (response) => {
          console.log('Movie added successfully:', response);
          this.movieForm.reset();
          // Reset the form or navigate to another page as needed
        },
        (error) => {
          console.error('Failed to add movie:', error);
        }
      );
      console.log(movieDetails);
    }
  }
}
