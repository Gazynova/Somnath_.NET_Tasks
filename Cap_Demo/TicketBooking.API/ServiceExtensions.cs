using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using TicketBooking.Application.Interface;
using TicketBooking.Infrastructure.Repository;
using TicketBooking.Application.Services;

namespace TicketBooking.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register repositories
            

            // Register MediatR handlers
            
        }
    }
}
