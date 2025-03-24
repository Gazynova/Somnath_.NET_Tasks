using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Models.ViewModels;

namespace Project_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Admin", "Dashboard");
                    }
                    else if (roles.Contains("Teacher"))
                    {
                        return RedirectToAction("Teacher", "Dashboard");
                    }
                    else if (roles.Contains("Student"))
                    {
                        return RedirectToAction("Student", "Dashboard");
                    }
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign the role based on the user role selected during registration
                    if (model.Role == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        return RedirectToAction("Admin", "Dashboard");
                    }
                    else if (model.Role == "Teacher")
                    {
                        await _userManager.AddToRoleAsync(user, "Teacher");
                        return RedirectToAction("Teacher", "Dashboard");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                        return RedirectToAction("Student", "Dashboard");
                    }
                }
                else
                {
                    // Add more debugging information to understand why login failed
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description); // This will give you more error info
                    }
                    return View(model);
                }
            }

            return View(model);
        }

        // POST: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
