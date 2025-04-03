using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Models.Identity;
using TicketBooking.Application.Interface;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
    {
        if (registrationRequest.Password != registrationRequest.ConfirmPassword)
        {
            return BadRequest("Password and Confirm Password do not match.");
        }

        var response = await _authService.Register(registrationRequest);
        return Ok(new { Message = "Registration successful", UserId = response.UserId });
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
    {
        var response = await _authService.Login(authRequest);
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("seed-admin")]
    public async Task<IActionResult> SeedAdmin()
    {
        await _authService.SeedAdminAsync();
        return Ok("Admin user and role seeded successfully.");
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst("uid")?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found in token.");
        }

        var userDTO = await _authService.GetCurrentUser(userId);
        return Ok(userDTO);
    }
}
