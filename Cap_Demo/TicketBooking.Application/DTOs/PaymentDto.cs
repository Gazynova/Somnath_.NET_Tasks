using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [RegularExpression("^(Success|Failed|Pending)$", ErrorMessage = "Invalid payment status.")]
        public string Status { get; set; } // Enforce allowed values
        public DateTime PaymentDate { get; set; }
    }



    public class PaymentResponseDto
    {
        public int PaymentId { get; set; } // Unique Payment ID
        public string Status { get; set; } // Payment status (e.g., Success, Failed)
        public DateTime PaymentDate { get; set; } // Date of the transaction
        public decimal Amount { get; set; } // Payment amount
        public string PaymentMethod { get; set; } // Payment method (Credit Card, PayPal, etc.)
    }

}

