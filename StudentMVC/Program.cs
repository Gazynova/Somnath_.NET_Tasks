using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Models;
using StudentMVC.Repositories; // Import your repository interfaces

namespace StudentMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a builder for the application
            var builder = WebApplication.CreateBuilder(args);

            //// Configure Serilog for logging
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console() // Logs to the console
            //    .WriteTo.File("Logs/app-log-.txt", rollingInterval: RollingInterval.Day) // Logs to a file
            //    .CreateLogger();
            //builder.Host.UseSerilog(); // Use Serilog for logging

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework Core and the database connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity services for user authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add custom services (repositories, etc.)
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            // Add custom email service (example)
            //builder.Services.AddScoped<IEmailSender, EmailSender>();

            // Configure authorization policies (example: role-based authorization)
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("TeacherOnly", policy => policy.RequireRole("Teacher"));
                options.AddPolicy("StudentOnly", policy => policy.RequireRole("Student"));
            });

            // Enable Razor Pages (optional if you use them)
            builder.Services.AddRazorPages();

            // Build the application
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // HTTP Strict Transport Security for production
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable routing
            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Set up default routing for MVC controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages(); // If you use Razor Pages

            // Run the application
            app.Run();
        }
    }
}
