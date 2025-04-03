using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TicketBooking.Application.Models.Identity;
using TicketBooking.Application.Interface;
using TicketBoking.Identity.Models;

namespace TicketBoking.Identity.Services
{
    public class AuthService : IAuthService

    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new Exception($"User with email {authRequest.Email} does not exist.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid password.");
            }

            var token = await GenerateToken(user);

            return new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            if (registrationRequest.Password != registrationRequest.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }

            var user = new User
            {
                Name = registrationRequest.Name,
                Email = registrationRequest.Email,
                UserName = registrationRequest.Username,
                //Role = "User", // Default role
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (!result.Succeeded)
            {
                throw new Exception($"Registration failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            await _userManager.AddToRoleAsync(user, "User");

            return new RegistrationResponse
            {
                UserId = user.Id
            };
        }

        public async Task<UserDTO> GetCurrentUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name
            };
        }

        public async Task SeedAdminAsync()
        {
            // Create Admin role if it doesn't exist
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create default Admin user
            var adminUser = await _userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    Name = "Admin User",
                    //Role = "Admin",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, "Admin@123"); // Default password
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenValididityMins),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
