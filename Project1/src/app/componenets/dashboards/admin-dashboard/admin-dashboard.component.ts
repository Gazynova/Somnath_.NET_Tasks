// admin-dashboard.component.ts
import { Component } from '@angular/core';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { Event } from '../../models/event.model';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { Booking } from '../../models/event.model';
import { SidebarComponent } from '../../shared/sidebar/sidebar.component';
import { HeaderComponent } from '../../shared/header/header.component';

@Component({
  selector: 'app-admin-dashboard',
  standalone:true,
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  imports : [FormsModule,NgFor,HeaderComponent]
})
export class AdminDashboardComponent {
  adminInfo: { name: string | null; email: string | null } = { name: '', email: '' };
  events: Event[] = [];
  allBookings: Booking[] = [];
  filteredBookings = [...this.allBookings];
  searchQuery = '';

  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit() {
    this.adminService.getAdminInfo().subscribe({
      next: (data) => {
        console.log("Admin Data:", data);
        this.adminInfo = data;
      },
      error: (error) => {
        console.error("Error fetching admin info", error);
      },
      complete: () => {
        console.log("Admin info fetch complete!");
      }
    });
    this.loadEvents();
}

  fetchAllBookings() {
    this.adminService.getAllBookings().subscribe(data => {
      this.allBookings = data;
      console.log(data);
    });
  }

  filterBookings() {
    this.filteredBookings = this.allBookings.filter(booking =>
      booking.userId.toString().includes(this.searchQuery) ||
      booking.status.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
  }
  
  loadEvents() {
    this.adminService.getEvents().subscribe(
      (data) => {
        console.log('Fetched events:', data); // Debugging
        this.events = data; 
      },
      (error) => {
        console.error('Error fetching events', error);
      }
    );
  }

  
  
  
  updateEvent(event: Event) {
    this.router.navigate(['/update-event', event.id]);
  }

  deleteEvent(id: number) {
    this.adminService.deleteEvent(id).subscribe(() => {
      this.loadEvents();
    });
  }

  addEvent() {
    this.router.navigate(['/add-event']);
  }

  
  
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}