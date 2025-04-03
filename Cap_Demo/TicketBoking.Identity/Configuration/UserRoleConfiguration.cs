using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBoking.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "41776008-6086-1fbf-b923-2879a6680b9a", // Administrator Role ID
                   UserId = "41776062-6086-1fbf-b923-2879a6680b9a"  // Admin User ID
               },
               new IdentityUserRole<string>
               {
                   RoleId = "41886008-6086-1fbf-b923-2879a6680b9a", // User Role ID
                   UserId = "41776062-6086-1fcf-b923-2879a6680b9a"  // Regular User ID
               }
            );
        }
    }
}
