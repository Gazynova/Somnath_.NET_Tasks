using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Demo
{
    public class EventCategory
    {
        [Key]
        public int Id { get; set; }
        public required string EventCategoryName { get; set; }

        //public Event Event { get; set; }
    }
}
