
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBoking.Identity.Context;
using TicketBoking.Identity.Models;
using TicketBoking.Identity.Services;
using TicketBooking.Application.Interface;

namespace TicketBoking.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext for Entity Framework
            services.AddDbContext<TicketBookingIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"), b => b.MigrationsAssembly(typeof(TicketBookingIdentityDbContext).Assembly.FullName)));
                
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TicketBookingIdentityDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
