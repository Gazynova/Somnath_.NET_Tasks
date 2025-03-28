using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Demo
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

        // Relationships
        public User User { get; set; }
        public Event Event { get; set; }
        public Payment Payment { get; set; }
    }
}
