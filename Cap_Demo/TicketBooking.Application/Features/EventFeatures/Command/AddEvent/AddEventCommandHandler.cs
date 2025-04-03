using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Interface;
using TicketBooking.Demo;
using MediatR;
using AutoMapper;


namespace TicketBooking.Application.Features.EventFeatures.Command.AddEvent
{
    
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, Event>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public AddEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Event> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = _mapper.Map<Event>(request.EventDto);
            return await _eventRepository.AddEvent(newEvent);
        }
    }

}
