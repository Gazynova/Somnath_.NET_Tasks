using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using TicketBooking.Application.Interface;
using System.Threading.Tasks;

namespace TicketBooking.Application.Features.PaymentFeatures.Command.DeletePayment
{
    

    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        private readonly IPaymentRepository _paymentRepository;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.DeletePayment(request.Id);
        }
    }

}
