import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Event, Booking } from '../../models/event.model';
import { FormsModule } from '@angular/forms';
import { CommonModule, NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';


@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css'],
  imports: [FormsModule, NgFor,CommonModule]
})
export class UserDashboardComponent implements OnInit {
  events: Event[] = [];
  userBookings: Booking[] = [];
  userId: string = '';
  showBookings: boolean = false; // Add this to toggle visibility

  constructor(
    private userService: UserService,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.userId = this.authService.getUserId() || '';
    console.log("Logged-in User ID:", this.userId);

    this.fetchEvents();
  }

  fetchEvents() {
    this.userService.getAllEvents().subscribe(data => {
      this.events = data;
    });
  }

  getUserBookings() {
    if (!this.userId) {
      console.error("User ID not found.");
      return;
    }

    if (!this.showBookings) {
      // Fetch bookings only when opening
      this.userService.getUserBookings().subscribe(data => {
        this.userBookings = data.filter(booking => booking.userId === this.userId);
        console.log("Filtered User Bookings:", this.userBookings);
        this.showBookings = true;
      }, error => {
        console.error("Error fetching bookings:", error);
      });
    } else {
      // Toggle off if already shown
      this.showBookings = false;
    }
  }

  bookEvent(event: Event) {
    if (!this.userId) {
      alert('User not logged in');
      return;
    }

    const booking: Booking = {
      id: 0,
      userId: this.userId,
      eventId: event.id,
      seatNumber: Math.floor(Math.random() * 100),
      bookingDate: new Date().toString(),
      status: 'Pending',
      event: event
    };

    this.userService.bookEvent(booking).subscribe(response => {
      alert('Booking successful!');
      this.getUserBookings(); // Refresh bookings list
    }, error => {
      console.error('Error booking event:', error);
    });
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  toggleBookings() {
    this.showBookings = !this.showBookings;
  }


}

