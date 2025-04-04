import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Event,Booking } from '../../models/event.model';
import { AdminService } from '../../dashboards/admin.service';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-booking',
  standalone:true,
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
  imports:[CommonModule,FormsModule]
})
export class BookingComponent implements OnInit {
  eventId!: number;
  eventDetails!: Event;
  tickets: number = 1;
  userId: string = 'user-id-placeholder';
  userName = "";

  constructor(
    private route: ActivatedRoute,
    private adminService: AdminService // ✅ Inject AdminService
  ) {}

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadEventDetails();
  }

  loadEventDetails(): void {
    this.adminService.getEventById(this.eventId).subscribe({
      next: (event) => {
        this.eventDetails = event;
      },
      error: (err) => {
        console.error('Error fetching event details:', err);
      }
    });
  }

  bookEvent(): void {
    const booking: Partial<Booking> = {
      userId: this.userId,
      eventId: this.eventId,
      seatNumber: this.tickets,
      bookingDate: new Date().toISOString(),
      status: 'Confirmed'
    };

    this.adminService.bookEvent(booking as Booking).subscribe({
      next: () => alert('Booking successful!'),
      error: (err) => {
        console.error('Booking failed:', err);
        alert('Failed to book. Try again later.');
      }
    });
  }
}
