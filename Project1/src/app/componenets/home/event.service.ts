import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking } from '../models/event.model';

@Injectable({
  providedIn: 'root' // Ensures it's available throughout the app
})
export class EventService {
  private apiUrl = 'https://localhost:7176/api/Events'; // Replace with your actual API

  constructor(private http: HttpClient) {}

  getAllEvents(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
  bookEvent(booking: Partial<Booking>) {
  return this.http.post<Booking>(this.apiUrl, booking);

  
}
}

