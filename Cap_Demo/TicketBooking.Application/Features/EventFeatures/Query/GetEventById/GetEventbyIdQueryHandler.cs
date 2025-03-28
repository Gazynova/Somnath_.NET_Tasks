using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Query.GetEventById
{
    public class GetEventbyIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        IEventRepository _eventRepository;
        public GetEventbyIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetEventById(request.id);
            return result;

        }
    }
}
