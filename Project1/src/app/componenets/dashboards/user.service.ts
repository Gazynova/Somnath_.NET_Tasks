// user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking,Event } from '../models/event.model';
@Injectable({
  providedIn: 'root'
})
export class UserService {
 
private apiUrl = 'https://localhost:7176/api/Bookings';
private eventUrl = 'https://localhost:7176/api';
  
  constructor(private http: HttpClient) {}

  getUserInfo(): Observable<any> {
    return this.http.get(`${this.apiUrl}/info`);
  }


  getAllEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.eventUrl}/Events`);
  }
 
  

  getUserBookings(): Observable<Booking[]> {
    return this.http.get<Booking[]>(`${this.apiUrl}`);
  }

  bookEvent(booking: Booking): Observable<Booking> {
    return this.http.post<Booking>(`${this.apiUrl}`, booking);
  }
  

}
