using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.PaymentFeatures.Command.NewFolder
{

    public record CreatePaymentCommand : IRequest<Payment>
    {
        public PaymentDto PaymentDto { get; set; }

        public CreatePaymentCommand(PaymentDto paymentDto)
        {
            PaymentDto = paymentDto;
        }
    }

}
