import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { ShowDetails } from 'src/app/models/show-details.model';

@Component({
  selector: 'app-current-shows',
  templateUrl: './current-shows.component.html',
  styleUrls: ['./current-shows.component.css']
})
export class CurrentShowsComponent implements OnInit {
  currentShows: ShowDetails[] = [];

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    // Load current shows on component initialization
    this.loadCurrentShows();
  }

  loadCurrentShows(): void {
    this.adminService.getCurrentShows().subscribe(
      (shows) => {
        console.log(shows);
        this.currentShows = shows;
      },
      (error) => {
        console.error('Failed to fetch current shows:', error);
      }
    );
  }
}
