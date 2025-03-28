using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Application.DTOs;
using TicketBooking.Application.Interface;

namespace TicketBooking.Application.Services
{
    public class EventCategoryService
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public EventCategoryService(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        // Get all categories as DTOs
        public async Task<IEnumerable<EventCategoryDto>> GetEventCategories()
        {
            var categories = await _eventCategoryRepository.GetEventCategories();

            return categories.Select(c => new EventCategoryDto
            {
                Id = c.Id,
                Name = c.EventCategoryName
            }).ToList();
        }

        // Get category by name (if needed elsewhere)
        public async Task<EventCategoryDto> GetEventCategoryByName(string name)
        {
            var category = await _eventCategoryRepository.GetEventCategoryByName(name);
            if (category == null) return null;

            return new EventCategoryDto
            {
                Id = category.Id,
                Name = category.EventCategoryName
            };
        }
    }
}
