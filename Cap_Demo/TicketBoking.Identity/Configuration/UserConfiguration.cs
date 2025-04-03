using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBoking.Identity.Models;

namespace TicketBoking.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.HasData(
                // Seed Admin User
                new User
                {
                    Id = "41776062-6086-1fbf-b923-2879a6680b9a", // Admin User ID
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    Name = "Admin System",
                    PasswordHash = hasher.HashPassword(new User
                    {
                        Id = "41776062-6086-1fbf-b923-2879a6680b9a",
                        UserName = "admin@gmail.com"
                    }, "Admin@123"),
                    //Role = "Admin", // Admin Role
                    EmailConfirmed = true
                },
                // Seed Regular User
                new User
                {
                    Id = "41776062-6086-1fcf-b923-2879a6680b9a", // Regular User ID
                    Email = "vani@gmail.com",
                    UserName = "vani@gmail.com",
                    Name = "Vani Shree",
                    PasswordHash = hasher.HashPassword(new User
                    {
                        Id = "41776062-6086-1fcf-b923-2879a6680b9a",
                        UserName = "vani@gmail.com"
                    }, "Vani@123"),
                    //Role = "User", // Default User Role
                    EmailConfirmed = true
                }
            );
        }
    }
}
