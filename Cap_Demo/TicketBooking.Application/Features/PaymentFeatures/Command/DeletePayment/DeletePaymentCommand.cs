using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBooking.Application.Features.PaymentFeatures.Command.DeletePayment
{
    

    public record DeletePaymentCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }

}
