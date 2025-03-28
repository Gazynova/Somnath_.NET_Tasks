using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class CreateEventDto
    {
        public string Name { get; set; }            // Name of the event
        public string Description { get; set; }     // Details about the event
        public DateTime Date { get; set; }          // Date and time of the event
        public string Venue { get; set; }           // Location of the event
        public int AvailableSeats { get; set; }     // Number of seats available
        public decimal Price { get; set; }          // Ticket price for the event
        public string EventCategoryName { get; set; } // Name of the event category (user-friendly input)
    }
}

