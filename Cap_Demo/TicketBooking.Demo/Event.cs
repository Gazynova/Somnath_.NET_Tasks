using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Demo
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }

        public int EventCategoryId { get; set; }
        public EventCategory eventType { get; set; }
        //// Relationships
        //public ICollection<Booking> Bookings { get; set; }
    }
}
