using TicketBooking.Demo;

namespace TicketBooking.Application.Interface
{
    public interface IBookingRepository
    {
        Task<Booking> AddBooking(Booking booking);
        Task<bool> DeleteBooking(int id);
        Task<Booking> GetBookingById(int id);
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> UpdateBooking(Booking booking);
    }
}
