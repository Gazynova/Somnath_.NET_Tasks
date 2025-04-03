using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBooking.Demo
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } // No ForeignKey attribute here

        // Relationships
        public Event Event { get; set; }
        public Payment Payment { get; set; }
    }
}
