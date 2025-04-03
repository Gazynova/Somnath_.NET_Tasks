using TicketBooking.Demo;
using TicketBooking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interface;

public class PaymentRepository : IPaymentRepository
{
    private readonly TicketBookingContext _context;

    public PaymentRepository(TicketBookingContext context)
    {
        _context = context;
    }

    public async Task<Payment> AddPayment(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<bool> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return false;

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Payment> GetPaymentById(int id)
    {
        return await _context.Payments.Include(p => p.Booking).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Payment>> GetPayments()
    {
        return await _context.Payments.Include(p => p.Booking).ToListAsync();
    }

    public async Task<Payment> UpdatePayment(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    // Optional: Uncomment if considering payment status
    // public async Task<IEnumerable<Payment>> GetPaymentsByStatus(string status)
    // {
    //     return await _context.Payments.Where(p => p.Status == status).ToListAsync();
    // }
}
