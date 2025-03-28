using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Command.AddEvent
{
    class AddEventCommandHandler
    {
        readonly IEventRepository _eventRepository;
        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            //var newEvent = new Event
            //{
            //    Name = request.Name,
            //    Date = request.Date,
            //    Artist = request.Artist,
            //    Price = request.Price
            //};
            return await _eventRepository.AddEvent(request._event);
        }
    }
}
