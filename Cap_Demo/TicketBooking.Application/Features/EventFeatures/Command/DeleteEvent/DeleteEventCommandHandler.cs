using MediatR;
using TicketBooking.Application.Features.EventFeatures.Command.DeleteEvent;
using TicketBooking.Application.Interface;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
{
    private readonly IEventRepository _eventRepository;

    public DeleteEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await _eventRepository.DeleteEvent(request.Id);
        if (!isDeleted)
        {
            throw new KeyNotFoundException($"Event with ID {request.Id} not found.");
        }
        return isDeleted;
    }
}
