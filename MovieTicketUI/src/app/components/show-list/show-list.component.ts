// movie-details.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-show-list',
  templateUrl: './show-list.component.html',
  styleUrls: ['./show-list.component.css']
})
export class ShowListComponent implements OnInit {
  movieId!: number;
  showDetails: any;

  constructor(private route: ActivatedRoute, private customerService: CustomerService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.movieId = +params['movieId'];
      this.loadShowDetails();
    });
  }

  loadShowDetails() {
    this.customerService.getShowDetails(this.movieId)
      .subscribe((data) => {     
        console.log(data);
        this.showDetails = data;
      },
      (error) => {
        console.error('Error fetching shows:', error);
      }
    );
  }
}
