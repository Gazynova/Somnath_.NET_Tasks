using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;


namespace TicketBooking.Application.Features.BokingFeatures.Query.GetBookingById
{
   
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetBookingById(request.Id);
        }
    }

}
