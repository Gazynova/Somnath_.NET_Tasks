using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Command.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var event1= await _eventRepository.GetEventById(request.id);
            if (event1 == null) return false;
            return await  _eventRepository.DeleteEvent(event1.Id);
            //await _eventRepository.SaveChangesAsync();
        }
    }
}
