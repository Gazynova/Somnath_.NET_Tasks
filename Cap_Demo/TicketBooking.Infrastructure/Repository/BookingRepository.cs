using TicketBooking.Demo;
using TicketBooking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interface;

public class BookingRepository : IBookingRepository
{
    private readonly TicketBookingContext _context;

    public BookingRepository(TicketBookingContext context)
    {
        _context = context;
    }

    public async Task<Booking> AddBooking(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<bool> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return false;

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Booking> GetBookingById(int id)
    {
        return await _context.Bookings
            .Include(b => b.Event)    // Include Event relationship
            .Include(b => b.Payment) 
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Booking>> GetBookings()
    {
        return await _context.Bookings
            .Include(b => b.Event)    // Include Event relationship
            .Include(b => b.Payment) 
            .ToListAsync();
    }

    public async Task<Booking> UpdateBooking(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
        return booking;
    }
}
