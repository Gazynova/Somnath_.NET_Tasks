export interface Event {
    id: number;
    name: string;
    description: string;
    date: string;
    venue: string;
    availableSeats: number;
    price: number;
    eventCategoryId: number;
    eventCategory: any;
  }
  
  export interface EventCategory {
    id: number;
    name: string;
  }

  export interface Booking {
    id: number;
    userId: string;
    eventId: number;
    seatNumber: number;
    bookingDate: string;
    status: string;
    event: Event;
    // payment?: Payment;
  }
  
  export interface Payment {
    id: number;
    bookingId: number;
    amount: number;
    paymentMethod: string;
    status: string;
    paymentDate: string;
  }