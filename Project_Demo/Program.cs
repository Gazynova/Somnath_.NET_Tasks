using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Demo.Data;
using Project_Demo.Models;
using Project_Demo.Repositories;
using Project_Demo.Services;

namespace Project_Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register ApplicationDbContext with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity services for user authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add custom repositories
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();


            // Optionally, add email service
            // builder.Services.AddScoped<IEmailSender, EmailSender>();

            // Configure authorization policies (role-based authorization)
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("TeacherOnly", policy => policy.RequireRole("Teacher"));
                options.AddPolicy("StudentOnly", policy => policy.RequireRole("Student"));
            });
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string[] roleNames = { "Admin", "Teacher", "Student" };

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Optionally, you can also create a default admin user if it doesn't exist
                var adminUser = await userManager.FindByEmailAsync("admin@domain.com");
                if (adminUser == null)
                {
                    var newUser = new ApplicationUser { UserName = "admin@domain.com", Email = "admin@domain.com" };
                    var result = await userManager.CreateAsync(newUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, "Admin");
                    }
                }
            }
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
