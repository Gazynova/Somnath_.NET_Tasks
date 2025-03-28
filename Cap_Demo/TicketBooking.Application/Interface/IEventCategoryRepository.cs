using System.Collections.Generic;
using System.Threading.Tasks;
using TicketBooking.Demo;

namespace TicketBooking.Application.Interface
{
    public interface IEventCategoryRepository
    {
        // Retrieve an EventCategory by its name
        Task<EventCategory> GetEventCategoryByName(string name);

        // Retrieve an EventCategory by its ID
        Task<EventCategory> GetEventCategoryById(int id);

        // Retrieve all EventCategories
        Task<IEnumerable<EventCategory>> GetEventCategories();
    }
}
