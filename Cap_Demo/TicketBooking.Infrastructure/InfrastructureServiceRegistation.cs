using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Interface;
using TicketBooking.Infrastructure.Context;
using TicketBooking.Infrastructure.Repository;

namespace TicketBooking.Infrastructure
{
    public static class InfrastructureServiceRegistation
    {
        public static IServiceCollection AddInfrastructureServiceRegistation(this IServiceCollection services,IConfiguration configuration)
        {
            // Configure DbContext for Entity Framework
            services.AddDbContext<TicketBookingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
