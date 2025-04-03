using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketBoking.Identity.Configuration;
using TicketBoking.Identity.Models;

namespace TicketBoking.Identity.Context
{
    public class TicketBookingIdentityDbContext : IdentityDbContext<User>
    {
        public TicketBookingIdentityDbContext(DbContextOptions<TicketBookingIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());


            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}
