using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Demo;
using MediatR;
using TicketBooking.Application.Interface;

namespace TicketBooking.Application.Features.BokingFeatures.Query.GetAllBooking
{
    

    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetBookings();
        }
    }

}
