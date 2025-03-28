


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Services;
using TicketBooking.Application.DTOs;

namespace TicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        // POST: Add a new event
        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent([FromBody] CreateEventDto createEventDto)
        {
            if (createEventDto == null)
            {
                return BadRequest("Event data is required.");
            }

            var createdEvent = await _eventService.AddEvent(createEventDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        //[HttpPut("UpdateEvent/{id}")]
        [HttpPut("UpdateEvent/{id}")]
        [HttpPut("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] CreateEventDto createEventDto)
        {
            if (createEventDto == null)
            {
                return BadRequest("Event data is required.");
            }

            var updatedEvent = await _eventService.UpdateEvent(id, createEventDto);
            if (updatedEvent == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(updatedEvent);
        }



        // DELETE: Delete an event by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleted = await _eventService.DeleteEvent(id);
            if (!deleted)
            {
                return NotFound("Event not found.");
            }
            return NoContent();
        }

        // GET: Get a specific event by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }
            return Ok(eventItem);
        }

        // GET: Get all events
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventService.GetEvents();
            return Ok(events);
        }

        // GET: Get all event categories (Dropdown for event creation)
        [HttpGet("categories")]
        public async Task<IActionResult> GetEventCategories()
        {
            var categories = await _eventService.GetEventCategories();
            if (categories == null || !categories.Any())
            {
                return NotFound("No event categories found.");
            }

            return Ok(categories);
        }
    }
}
