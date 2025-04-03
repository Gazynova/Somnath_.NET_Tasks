namespace TicketBooking.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Name { get; set; } // Full name of the user
        public string Email { get; set; } // Email address
        public string Username { get; set; } // Username
        public string Password { get; set; } // Password
        public string ConfirmPassword { get; set; } // Confirmation of the password
    }
}
