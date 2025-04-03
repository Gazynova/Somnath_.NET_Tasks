using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.EventFeatures.Command.DeleteEvent
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteEventCommand(int id)
        {
            Id = id;
        }
    }
}
