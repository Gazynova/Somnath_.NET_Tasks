using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicketBooking.Demo
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
