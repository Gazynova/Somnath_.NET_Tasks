using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }

        // Include EventCategory information
        public int EventCategoryId { get; set; }
        //public string CategoryName { get; set; } // Optional, for displaying the category name
        //public string EventCategoryName { get; internal set; }
    }
}

