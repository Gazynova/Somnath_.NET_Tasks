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

        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Called once at the start

            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventCategoyConfiguration());
        }
    }
}
