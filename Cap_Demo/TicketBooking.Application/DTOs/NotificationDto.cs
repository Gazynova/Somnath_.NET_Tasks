using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class NotificationDto
    {
        public int UserId { get; set; } // Recipient user ID
        public string Message { get; set; } // Notification message
        public DateTime Timestamp { get; set; } // Time the notification was sent
    }

}
