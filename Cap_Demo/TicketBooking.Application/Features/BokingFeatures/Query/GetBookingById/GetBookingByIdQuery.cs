using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.BokingFeatures.Query
{
    

    public record GetBookingByIdQuery : IRequest<Booking>
    {
        public int Id { get; set; }

        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }
    }

}
