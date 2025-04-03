using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using AutoMapper;


namespace TicketBooking.Application.Features.BokingFeatures.Command
{

   
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var newBooking = _mapper.Map<Booking>(request.BookingDto);

            // Retrieve the corresponding event
            var eventDetails = await _eventRepository.GetEventById(newBooking.EventId);
            if (eventDetails == null)
            {
                throw new KeyNotFoundException($"Event with ID {newBooking.EventId} not found.");
            }

            // Check seat availability
            if (eventDetails.AvailableSeats < newBooking.SeatNumber)
            {
                throw new InvalidOperationException("Not enough seats available for this event.");
            }

            // Adjust available seats
            eventDetails.AvailableSeats -= newBooking.SeatNumber;
            await _eventRepository.UpdateEvent(eventDetails);

            // Create booking
            return await _bookingRepository.AddBooking(newBooking);
        }
    }


}
