using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

public class UpdateEventCommand : IRequest<Event>
{
    public int Id { get; set; }
    public EventDto EventDto { get; set; }

    public UpdateEventCommand(int id, EventDto eventDto)
    {
        Id = id;
        EventDto = eventDto;
    }
}
