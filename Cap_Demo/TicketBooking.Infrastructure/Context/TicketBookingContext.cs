using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Demo;
using TicketBooking.Infrastructure.Configuration;

namespace TicketBooking.Infrastructure.Context
{
    public class TicketBookingContext : DbContext
    {
        public TicketBookingContext(DbContextOptions<TicketBookingContext> options) : base(options)
        {
        }

        public DbSet<Event> events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EventConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventCategoyConfiguration());
            base.OnModelCreating(modelBuilder);



        }

    }
}
