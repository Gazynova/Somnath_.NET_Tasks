using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Demo.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Teacher()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public IActionResult Student()
        {
            return View();
        }

    }
}
