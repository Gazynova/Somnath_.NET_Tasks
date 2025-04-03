// booking-payment.component.ts
import { Component } from '@angular/core';
import { UserService } from '../../dashboards/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Event, Booking, Payment } from '../../models/event.model';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-booking-payment',
  standalone:true,
  templateUrl: './booking-payment.component.html',
  styleUrls: ['./booking-payment.component.css'],
  imports:[FormsModule,NgFor]
})
export class BookingPaymentComponent {
  event: Event = {} as Event;
  payment: Payment = { id: 0, bookingId: 0, amount: 0, paymentMethod: 'UPI', status: 'Pending', paymentDate: '' };

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    const eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.userService.getUserBookings().subscribe(bookings => {
      const booking = bookings.find(b => b.eventId === eventId);
      if (booking) {
        this.event = booking.event;
        this.payment.amount = this.event.price;
      }
    });
  }

  processPayment() {
    // Logic for payment processing can be added here
    this.router.navigate(['/userdashboard']);
  }

  cancelPayment() {
    this.router.navigate(['/user-dashboard']);
  }
}
