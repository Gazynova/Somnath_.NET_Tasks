import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from '../../dashboards/admin.service';
import { Event,EventCategory } from '../../models/event.model';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';


@Component({
  selector: 'app-update-event',
  standalone:true,
  templateUrl: './update-event.component.html',
  styleUrls: ['./update-event.component.css'],
  imports:[FormsModule,NgFor]
})
export class UpdateEventComponent implements OnInit {
  event: Event = {
    id: 0,
    name: '',
    description: '',
    date: '',
    venue: '',
    availableSeats: 0,
    price: 0,
    eventCategoryId: 0,
    eventCategory: null
  };

  categories: EventCategory[] = [];

  constructor(
    private route: ActivatedRoute,
    private adminService: AdminService,
    private router: Router
  ) {}

  ngOnInit() {
    const eventId = Number(this.route.snapshot.paramMap.get('id'));
    if (eventId) {
      this.adminService.getEventById(eventId).subscribe(
        (data) => {
          this.event = data;
        },
        (error) => {
          console.error('Error fetching event data', error);
        }
      );
    }
    this.adminService.getEventCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error('Error fetching categories', error);
      }
    );
  }


  updateEvent() {
    this.adminService.updateEvent(this.event).subscribe(() => {
      this.router.navigate(['/admindashboard']);
    });
  }

  cancelUpdate() {
    this.router.navigate(['/admindashboard']);
  }
}
