using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.BokingFeatures.Query.GetAllBooking
{
    

    public class GetAllBookingsQuery : IRequest<IEnumerable<Booking>> { }

}
