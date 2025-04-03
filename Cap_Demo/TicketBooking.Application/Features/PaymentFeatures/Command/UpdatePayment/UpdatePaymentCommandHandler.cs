using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using AutoMapper;
namespace TicketBooking.Application.Features.PaymentFeatures.Command.UpdatePayment
{


    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Payment> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var existingPayment = await _paymentRepository.GetPaymentById(request.Id);
            if (existingPayment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {request.Id} not found.");
            }

            _mapper.Map(request.PaymentDto, existingPayment);
            return await _paymentRepository.UpdatePayment(existingPayment);
        }
    }

}
