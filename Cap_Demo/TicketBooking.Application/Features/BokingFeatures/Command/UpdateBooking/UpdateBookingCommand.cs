using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

namespace TicketBooking.Application.Features.BokingFeatures.Command.UpdateBooking
{


    public record UpdateBookingCommand : IRequest<Booking>
    {
        public int Id { get; set; }
        public BookingDto BookingDto { get; set; }

        public UpdateBookingCommand(int id, BookingDto bookingDto)
        {
            Id = id;
            BookingDto = bookingDto;
        }
    }

}
