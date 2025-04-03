using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Query.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEvents();
        }
    }

}

