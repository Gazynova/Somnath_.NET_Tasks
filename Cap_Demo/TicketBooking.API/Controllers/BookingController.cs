using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.DTOs;
using TicketBooking.Application.Features.BokingFeatures.Command.DeleteBooking;
using TicketBooking.Application.Features.BokingFeatures.Command.UpdateBooking;
using TicketBooking.Application.Features.BokingFeatures.Command;
using TicketBooking.Application.Features.BokingFeatures.Query.GetAllBooking;
using TicketBooking.Application.Features.BokingFeatures.Query;
using TicketBooking.Demo;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Get all bookings
    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _mediator.Send(new GetAllBookingsQuery());
        return Ok(bookings);
    }

    // Get booking by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _mediator.Send(new GetBookingByIdQuery(id));
        if (booking == null)
        {
            return NotFound($"Booking with ID {id} not found.");
        }
        return Ok(booking);
    }

    // Create a new booking
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        var createdBooking = await _mediator.Send(new CreateBookingCommand(bookingDto));
        return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
    }

    // Update an existing booking
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
    {
        var updatedBooking = await _mediator.Send(new UpdateBookingCommand(id, bookingDto));
        return Ok(updatedBooking);
    }

    // Delete a booking
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var isDeleted = await _mediator.Send(new DeleteBookingCommand(id));
        if (!isDeleted)
        {
            return NotFound($"Booking with ID {id} not found.");
        }
        return NoContent();
    }
}
