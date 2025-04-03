using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Demo;
using TicketBooking.Application.Interface;
using AutoMapper;
using TicketBooking.Application.Features.PaymentFeatures.Command.NewFolder;


namespace TicketBooking.Application.Features.PaymentFeatures.Command.CreatePayment
{
    
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Payment> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var newPayment = _mapper.Map<Payment>(request.PaymentDto);
            return await _paymentRepository.AddPayment(newPayment);
        }
    }

}
