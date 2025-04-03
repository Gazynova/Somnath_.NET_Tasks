using AutoMapper;
using TicketBooking.Application.DTOs;
using TicketBooking.Demo;

namespace TicketBooking.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
        }
    }
}
