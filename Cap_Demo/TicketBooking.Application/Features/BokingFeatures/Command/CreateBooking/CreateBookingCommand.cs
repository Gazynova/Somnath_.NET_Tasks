using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.BokingFeatures.Command
{
    public record CreateBookingCommand : IRequest<Booking>
    {
        public BookingDto BookingDto { get; set; }

        public CreateBookingCommand(BookingDto bookingDto)
        {
            BookingDto = bookingDto;
        }
    }
}
