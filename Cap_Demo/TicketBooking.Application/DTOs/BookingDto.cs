using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class BookingDto
    {
        public string UserId { get; set; }
        public int EventId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seat number must be greater than 0.")]
        public int SeatNumber { get; set; }

        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }


    //public class BookingResponseDto
    //{
    //    public int BookingId { get; set; } // Booking ID
    //    public string Status { get; set; } // Booking status (e.g., Confirmed, Cancelled)
    //    public string SeatNumber { get; set; } // Seat number
    //    public DateTime BookingDate { get; set; } // Date of booking
    //}
}
