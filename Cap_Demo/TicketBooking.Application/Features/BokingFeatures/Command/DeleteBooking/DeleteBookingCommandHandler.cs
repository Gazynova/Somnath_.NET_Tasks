using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.Interface;


namespace TicketBooking.Application.Features.BokingFeatures.Command.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;

        public DeleteBookingCommandHandler(IBookingRepository bookingRepository, IEventRepository eventRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            // Retrieve booking
            var booking = await _bookingRepository.GetBookingById(request.Id);
            if (booking == null)
            {
                throw new KeyNotFoundException($"Booking with ID {request.Id} not found.");
            }

            // Retrieve the corresponding event
            var eventDetails = await _eventRepository.GetEventById(booking.EventId);
            if (eventDetails != null)
            {
                // Adjust available seats
                eventDetails.AvailableSeats += booking.SeatNumber;
                await _eventRepository.UpdateEvent(eventDetails);
            }

            // Delete booking
            return await _bookingRepository.DeleteBooking(request.Id);
        }
    }


}
