//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TicketBooking.Application.DTOs;
//using TicketBooking.Application.Interface;
//using TicketBooking.Demo;

//namespace TicketBooking.Application.Services
//{
//    public class PaymentService
//    {
//        private readonly IPaymentRepository _repository;

//        public PaymentService(IPaymentRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
//        {
//            return await _repository.GetAllAsync();
//        }

//        public async Task<Payment> GetPaymentByIdAsync(int id)
//        {
//            return await _repository.GetByIdAsync(id);
//        }

//        public async Task<Payment> CreatePaymentAsync(Payment payment)
//        {
//            return await _repository.AddAsync(payment);
//        }

//        public async Task<Payment> UpdatePaymentAsync(Payment payment)
//        {
//            return await _repository.UpdateAsync(payment);
//        }

//        public async Task DeletePaymentAsync(int id)
//        {
//            await _repository.DeleteAsync(id);
//        }


//        public async Task<PaymentResponseDto> ProcessPaymentAsync(int bookingId, decimal amount, string paymentMethod)
//        {
//            // Simulate payment processing logic
//            var payment = new Payment
//            {
//                BookingId = bookingId,
//                Amount = amount,
//                PaymentMethod = paymentMethod,
//                Status = "Success", // Assume success for now
//                PaymentDate = DateTime.UtcNow
//            };

//            await _repository.AddAsync(payment);

//            return new PaymentResponseDto
//            {
//                PaymentId = payment.Id,
//                Status = payment.Status,
//                PaymentDate = payment.PaymentDate
//            };
//        }


//    }

//}
