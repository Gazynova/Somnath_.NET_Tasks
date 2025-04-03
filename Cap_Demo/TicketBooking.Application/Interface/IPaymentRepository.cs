using TicketBooking.Demo;

namespace TicketBooking.Application.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
        Task<bool> DeletePayment(int id);
        Task<Payment> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetPayments();

        Task<Payment> UpdatePayment(Payment payment);
            // Optional: Methods to consider PaymentStatus
            // Task<IEnumerable<Payment>> GetPaymentsByStatus(string status);

    }
}
