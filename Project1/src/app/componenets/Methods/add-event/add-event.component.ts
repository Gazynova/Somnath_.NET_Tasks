// add-event.component.ts
import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../dashboards/admin.service';
import { Event,EventCategory } from '../../models/event.model';
import { Router } from '@angular/router';
import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-event',
  standalone:true,
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css'],
  imports: [NgFor,FormsModule]
})
export class AddEventComponent implements OnInit {
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

  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit() {
    this.adminService.getEventCategories().subscribe(
      (data) => {
        console.log("Fetched categories:", data); // Debugging
        this.categories = data;
  
        // Set default category if categories exist
        if (this.categories.length > 0) {
          this.event.eventCategoryId = this.categories[0].id; 
        }
      },
      (error) => {
        console.error('Error fetching event categories', error);
      }
    );
  }
  

  submitEvent() {
    // Ensure the selected category ID is assigned properly
    const selectedCategory = this.categories.find(
      (category) => category.id === this.event.eventCategoryId
    );
  
    if (!selectedCategory) {
      console.error('No category selected');
      return;
    }
  
    // Assign the selected category ID
    this.event.eventCategoryId = selectedCategory.id;
  
    console.log('Submitting event:', this.event); // Debugging
  
    this.adminService.addEvent(this.event).subscribe(
      (response) => {
        console.log('Event added successfully:', response);
        this.router.navigate(['/admindashboard']);
      },
      (error) => {
        console.error('Error adding event:', error);
      }
    );
  }

  cancelCreate() {
    this.router.navigate(['/admindashboard']);
  }
  
}
