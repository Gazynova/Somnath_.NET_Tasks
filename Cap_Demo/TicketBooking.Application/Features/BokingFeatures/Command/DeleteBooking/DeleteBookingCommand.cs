using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBooking.Application.Features.BokingFeatures.Command.DeleteBooking
{

    public record DeleteBookingCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;
        }
    }

}
