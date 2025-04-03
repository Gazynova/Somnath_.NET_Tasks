using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;

namespace TicketBooking.Application.Features.PaymentFeatures.Query.GetPaymentById
{

    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPaymentById(request.Id);
        }
    }

}
