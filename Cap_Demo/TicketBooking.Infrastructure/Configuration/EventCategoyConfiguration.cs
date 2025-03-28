using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Demo;
namespace TicketBooking.Infrastructure.Configuration
{
    public class EventCategoyConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasData(
                new EventCategory
                {
                    Id = 1,
                    EventCategoryName = "Music"
                },
                new EventCategory
                {
                    Id = 2,
                    EventCategoryName = "Conference"
                },
                new EventCategory
                {
                    Id = 3,
                    EventCategoryName = "Sports"
                }
            );
                
        }
    }
}