using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookingDto
    {
        public int EventId { get; set; }
        public string SeatNumber { get; set; }
    }

    public class BookingResponseDto
    {
        public int BookingId { get; set; } // Booking ID
        public string Status { get; set; } // Booking status (e.g., Confirmed, Cancelled)
        public string SeatNumber { get; set; } // Seat number
        public DateTime BookingDate { get; set; } // Date of booking
    }
}
