using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.DTOs;
using TicketBooking.Application.Features.EventFeatures.Command.AddEvent;
using TicketBooking.Application.Features.EventFeatures.Command.DeleteEvent;
using TicketBooking.Application.Features.EventFeatures.Query.GetAllEvents;
using TicketBooking.Application.Features.EventFeatures.Query.GetEventById;
using TicketBooking.Demo;

namespace TicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all events
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _mediator.Send(new GetAllEventsQuery());
            return Ok(events);
        }

        // Get event by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventDetails = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(eventDetails);
        }

        // Add a new event
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventDto eventDto)
        {
            var addedEvent = await _mediator.Send(new AddEventCommand(eventDto));
            return Ok(addedEvent);
        }

        // Update an existing event
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id,[FromBody] EventDto eventDto)
        {
            var updatedEvent = await _mediator.Send(new UpdateEventCommand(id, eventDto));
            return Ok(updatedEvent);
        }

        // Delete an event
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteEventCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound($"Event with ID {id} not found.");
        }
    }

}