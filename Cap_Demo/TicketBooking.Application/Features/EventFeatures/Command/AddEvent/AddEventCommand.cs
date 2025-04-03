using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Command.AddEvent
{
    public record AddEventCommand(EventDto EventDto) : IRequest<Event>
    {

    }
}
