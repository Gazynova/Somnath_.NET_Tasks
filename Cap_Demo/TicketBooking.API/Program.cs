using TicketBooking.Application.Services;
using TicketBooking.Infrastructure.Repository;
using TicketBooking.Application.Interface;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Models.Identity;
using TicketBooking.Application;
using TicketBooking.Infrastructure;
using TicketBoking.Identity;

namespace TicketBooking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddApplicationServiceRegistration();
            builder.Services.AddIdentityServiceRegistration(builder.Configuration);
            builder.Services.AddInfrastructureServiceRegistation(builder.Configuration);
            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

            // Add JWT Authentication
            var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"] ?? throw new InvalidOperationException("JWT Key is missing"));
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Register Authorization services
            builder.Services.AddAuthorization();

            // Register application services and repositories
            builder.Services.ConfigureServices();


            // Configure Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Add middleware
            app.UseHttpsRedirection();
            app.UseCors("AllowAll"); // Apply CORS policy
            app.UseAuthentication(); // Use authentication middleware
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
