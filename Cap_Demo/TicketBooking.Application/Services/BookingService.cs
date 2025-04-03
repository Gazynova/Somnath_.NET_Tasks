//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TicketBooking.Application.Interface;
//using TicketBooking.Demo;

//namespace TicketBooking.Application.Services
//{
//    public class BookingService
//    {
//        private readonly IBookingRepository _bookingRepository;
//        private readonly IEventRepository _eventRepository;
//        private readonly PaymentService _paymentService;

//        public BookingService(IBookingRepository bookingRepository, IEventRepository eventRepository, PaymentService paymentService)
//        {
//            _bookingRepository = bookingRepository;
//            _eventRepository = eventRepository;
//            _paymentService = paymentService;
//        }

//        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
//        {
//            return await _bookingRepository.GetAllAsync();
//        }

//        public async Task<Booking> GetBookingByIdAsync(int id)
//        {
//            return await _bookingRepository.GetByIdAsync(id);
//        }

//        public async Task<Booking> CreateBookingAsync(Booking booking)
//        {
//            // Fetch event details
//            var eventDetails = await _eventRepository.GetEventById(booking.EventId);
//            if (eventDetails == null)
//            {
//                throw new Exception("Event not found.");
//            }

//            // Check seat availability
//            if (eventDetails.AvailableSeats <= 0)
//            {
//                throw new Exception("No seats available.");
//            }

//            // Reduce available seats
//            eventDetails.AvailableSeats -= 1;
//            await _eventRepository.UpdateEvent(eventDetails);

//            // Save booking
//            var createdBooking = await _bookingRepository.AddBookingAsync(booking);

//            // Process Payment
//            var payment = new Payment
//            {
//                BookingId = createdBooking.Id,
//                Amount = eventDetails.Price, // Event price
//                PaymentMethod = "CreditCard",
//                Status = "Pending"
//            };

//            var paymentResult = await _paymentService.ProcessPaymentAsync(payment.BookingId,payment.Amount,payment.PaymentMethod);

//            // Update booking status based on payment
//            if (paymentResult.Status == "Success")
//            {
//                createdBooking.Status = "Confirmed";
//            }
//            else
//            {
//                createdBooking.Status = "Failed";
//                eventDetails.AvailableSeats += 1; // Revert seat reduction
//                await _eventRepository.UpdateEvent(eventDetails);
//            }

//            await _bookingRepository.UpdateAsync(createdBooking);

//            return createdBooking;
//        }


//        public async Task<Booking> UpdateBookingAsync(Booking booking)
//        {
//            return await _bookingRepository.UpdateAsync(booking);
//        }

//        public async Task DeleteBookingAsync(int id)
//        {
//            await _bookingRepository.DeleteAsync(id);
//        }
//    }

//}
