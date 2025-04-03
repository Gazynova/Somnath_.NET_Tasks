// admin.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Event,EventCategory,Booking } from '../models/event.model';


@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:7176/api';

  constructor(private http: HttpClient) {}

  getAdminInfo(): Observable<any> {
    return this.http.get(`${this.apiUrl}/info`);
  }

  getEvents(): Observable<Event[]> {
    console.log("Calling API:", `${this.apiUrl}/Events`); // Debugging
    return this.http.get<Event[]>(`${this.apiUrl}/Events`);
  }
  

  getEventCategories(): Observable<EventCategory[]> {
    return this.http.get<EventCategory[]>(`${this.apiUrl}/EventCategory`);
  }

  addEvent(event: Event): Observable<Event> {
    return this.http.post<Event>(`${this.apiUrl}/Events`, event);
  }

  updateEvent(event: Event): Observable<Event> {
    return this.http.put<Event>(`${this.apiUrl}/Events/${event.id}`, event);
  }

  deleteEvent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Events/${id}`);
  }


  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/Events/${id}`);
  }

  getAllBookings(): Observable<Booking[]> {
    return this.http.get<Booking[]>(`${this.apiUrl}/Bookings`);
  }

  bookEvent(booking: Booking): Observable<Booking> {
    return this.http.post<Booking>(`${this.apiUrl}/Bookings`, booking);
  }


}
