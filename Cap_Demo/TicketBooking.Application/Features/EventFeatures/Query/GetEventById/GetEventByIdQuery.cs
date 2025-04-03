using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Query.GetEventById
{
    public class GetEventByIdQuery : IRequest<Event>
    {
        public int Id { get; set; }

        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
