using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.DTOs;
using TicketBooking.Application.Services;

namespace TicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventCategoryController : ControllerBase
    {
        private readonly EventCategoryService _eventCategoryService;

        public EventCategoryController(EventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        // GET: api/EventCategory
        // Get all event categories for dropdown
        [HttpGet]
        public async Task<IActionResult> GetEventCategories()
        {
            var categories = await _eventCategoryService.GetEventCategories();
            if (categories == null || !categories.Any())
            {
                return NotFound("No event categories found.");
            }

            return Ok(categories);
        }
    }
}
