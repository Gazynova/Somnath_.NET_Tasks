using TicketBooking.Application.Models.Identity;

namespace TicketBooking.Application.Interface
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
        Task<UserDTO> GetCurrentUser(string userId);
        Task SeedAdminAsync(); // New method for seeding admin
        Task Logout(); // New method for logout
    }
}
