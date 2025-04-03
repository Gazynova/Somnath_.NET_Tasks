using System.Reflection;
using AutoMapper.Internal;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Services;

namespace TicketBooking.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));


            // Register AutoMapper profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register application services
            //services.AddScoped<EventService>();
            services.AddScoped<EventCategoryService>();
            //services.AddScoped<BookingService>();
            //services.AddScoped<PaymentService>();

            return services;
        }
    }
}
