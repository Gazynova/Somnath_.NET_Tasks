using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class PaymentDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class PaymentResponseDto
    {
        public int PaymentId { get; set; } // Payment ID
        public string Status { get; set; } // Payment status (e.g., Success, Failed)
        public DateTime PaymentDate { get; set; } // Date of payment
    }
}

