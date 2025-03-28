using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Demo;

namespace TicketBooking.Infrastructure.Context
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    //event data to be filled here
                    Id = 1,
                    Name = "Amit Mishra",
                    Description = "Amit Mishra Live Concert",
                    Date = new DateTime(2021, 12, 25),


                    Venue = "Mumbai",
                    AvailableSeats = 1000,
                    Price = 500,
                    EventCategoryId = 1,
                },
                new Event
                {
                    Id = 2,
                    Name = "Arijit Singh",
                    Description = "Arijit Singh Live Concert",
                    Date = new DateTime(2021, 12, 25),
                    Venue = "Mumbai",
                    AvailableSeats = 1000,
                    Price = 500,
                    EventCategoryId = 1,
                },
                new Event
                {
                    Id = 3,
                    Name = "Nvidia  GTC",
                    Description = "Nvidia GTC Conference",
                    Date = new DateTime(2025, 12, 25),
                    Venue = "Mumbai",
                    AvailableSeats =500,
                    Price = 100,
                    EventCategoryId =2,
                });
        }
    }
}