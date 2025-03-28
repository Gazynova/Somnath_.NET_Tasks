using TicketBooking.Application.Services;
using TicketBooking.Infrastructure.Repository;
using TicketBooking.Application.Interface;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Infrastructure.Context;
using TicketBooking.Demo;

namespace TicketBooking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register dependencies
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
            builder.Services.AddScoped<EventService>();
            builder.Services.AddScoped<EventCategoryService>();

            // Configure Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure DbContext for Entity Framework
            builder.Services.AddDbContext<TicketBookingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Add middleware
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
