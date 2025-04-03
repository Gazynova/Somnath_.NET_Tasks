using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Query.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<IEnumerable<Event>>
    {
    }
    
}
