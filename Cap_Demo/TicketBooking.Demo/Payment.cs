using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBooking.Demo
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }

        // Relationships
        public Booking Booking { get; set; }
    }
}
