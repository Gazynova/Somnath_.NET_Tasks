using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Data;
using Project_Demo.Models;
using Project_Demo.Models.ViewModels;
using Project_Demo.Services;
using System.Threading.Tasks;

namespace Project_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        readonly ApplicationDbContext _studentManegementDbContext;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext studentManegementDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _studentManegementDbContext = studentManegementDbContext;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError(string.Empty, "You must confirm your email before logging in.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                    return RedirectToAction("Admin", "Dashboard");
                if (roles.Contains("Teacher"))
                    return RedirectToAction("Teacher", "Dashboard");
                if (roles.Contains("Student"))
                    return RedirectToAction("Student", "Dashboard");

                return RedirectToLocal("/");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account has been locked due to multiple failed attempts. Try again later.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
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
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.FirstName + model.LastName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    NormalizedEmail = model.Email,

                    //FirstName = model.FirstName,
                    //LastName = model.LastName,
                    //DateOfBirth = model.DateOfBirth
                };


                var student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    ApplicationUserId = user.Id,

                };


                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign the selected role
                    await _userManager.AddToRoleAsync(user, model.Role);
                    if (model.Role == "Student")
                    {
                        _studentManegementDbContext.Students.AddAsync(student);
                        await _studentManegementDbContext.SaveChangesAsync();
                    }

                    

                    return RedirectToAction($"{model.Role}", "Dashboard");
                     
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed.");
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
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
