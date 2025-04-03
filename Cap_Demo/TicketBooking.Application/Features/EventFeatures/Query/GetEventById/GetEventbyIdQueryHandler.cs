using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using TicketBooking.Application.Features.EventFeatures.Query.GetEventById;

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var eventDetails = await _eventRepository.GetEventById(request.Id);
        if (eventDetails == null)
        {
            throw new KeyNotFoundException($"Event with ID {request.Id} not found.");
        }
        return eventDetails;
    }
}
