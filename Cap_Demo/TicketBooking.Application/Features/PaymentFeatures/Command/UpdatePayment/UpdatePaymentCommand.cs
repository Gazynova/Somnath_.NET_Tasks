using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;
namespace TicketBooking.Application.Features.PaymentFeatures.Command.UpdatePayment
{


    public record UpdatePaymentCommand : IRequest<Payment>
    {
        public int Id { get; set; }
        public PaymentDto PaymentDto { get; set; }

        public UpdatePaymentCommand(int id, PaymentDto paymentDto)
        {
            Id = id;
            PaymentDto = paymentDto;
        }
    }

}
