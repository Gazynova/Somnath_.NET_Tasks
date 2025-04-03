using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using AutoMapper;


namespace TicketBooking.Application.Features.BokingFeatures.Command.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IBookingRepository bookingRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Booking> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var existingBooking = await _bookingRepository.GetBookingById(request.Id);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException($"Booking with ID {request.Id} not found.");
            }

            // Retrieve the corresponding event
            var eventDetails = await _eventRepository.GetEventById(existingBooking.EventId);
            if (eventDetails == null)
            {
                throw new KeyNotFoundException($"Event with ID {existingBooking.EventId} not found.");
            }

            // Adjust seats based on the difference between old and new SeatNumber
            int seatDifference = request.BookingDto.SeatNumber - existingBooking.SeatNumber;

            if (eventDetails.AvailableSeats - seatDifference < 0)
            {
                throw new InvalidOperationException("Not enough seats available for this event.");
            }

            eventDetails.AvailableSeats -= seatDifference;
            await _eventRepository.UpdateEvent(eventDetails);

            // Update booking details
            _mapper.Map(request.BookingDto, existingBooking);
            return await _bookingRepository.UpdateBooking(existingBooking);
        }
    }


}
