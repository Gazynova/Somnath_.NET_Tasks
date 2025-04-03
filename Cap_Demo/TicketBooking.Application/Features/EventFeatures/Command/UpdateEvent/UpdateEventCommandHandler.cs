using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using AutoMapper;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var existingEvent = await _eventRepository.GetEventById(request.Id);
        if (existingEvent == null)
        {
            throw new KeyNotFoundException($"Event with ID {request.Id} not found.");
        }

        _mapper.Map(request.EventDto, existingEvent);
        return await _eventRepository.UpdateEvent(existingEvent);
    }
}
