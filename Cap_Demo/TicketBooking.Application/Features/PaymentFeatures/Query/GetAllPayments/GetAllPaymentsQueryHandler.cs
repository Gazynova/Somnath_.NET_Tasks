using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;

namespace TicketBooking.Application.Features.PaymentFeatures.Query.GetAllPayments
{
    

    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPayments();
        }
    }

}
