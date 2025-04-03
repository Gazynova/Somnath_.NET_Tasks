using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
namespace TicketBooking.Application.Features.PaymentFeatures.Query.GetPaymentById
{


    public record GetPaymentByIdQuery : IRequest<Payment>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }

}
