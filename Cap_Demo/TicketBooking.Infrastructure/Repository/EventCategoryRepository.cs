using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;
using TicketBooking.Infrastructure.Context;

namespace TicketBooking.Infrastructure.Repository
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly TicketBookingContext _dbContext;

        public EventCategoryRepository(TicketBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EventCategory> GetEventCategoryByName(string name)
        {
            return await _dbContext.EventCategories.FirstOrDefaultAsync(c => c.EventCategoryName == name);
        }

        public async Task<EventCategory> GetEventCategoryById(int id)
        {
            return await _dbContext.EventCategories.FindAsync(id);
        }

        public async Task<IEnumerable<EventCategory>> GetEventCategories()
        {
            return await _dbContext.EventCategories.ToListAsync();
        }
    }
}
