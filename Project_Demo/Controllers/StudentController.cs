using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_Demo.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return View(students);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching students.");
            }
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        public async Task<IActionResult> MyProfile()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var student = await _studentService.GetStudentByUserIdAsync(userId);

                if (student == null)
                {
                    return NotFound("Student profile not found.");
                }

                return View(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching the profile.");
            }
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            try
            {
                var user = await _userManager.FindByIdAsync(student.ApplicationUserId);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid User ID.");
                    return View(student);
                }

                await _studentService.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the student.");
            }
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var student = await _studentService.GetStudentByUserIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                if (User.IsInRole("Student") && student.ApplicationUserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Forbid(); // Prevent students from accessing others' details
                }

                return View(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching student details.");
            }
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var student = await _studentService.GetStudentByUserIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                if (User.IsInRole("Student") && student.ApplicationUserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Forbid(); // Prevent students from editing others' data
                }

                return View(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching student for editing.");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Edit(string id, Student student)
        {
            if (id != student.ApplicationUserId)
            {
                return BadRequest("Student ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            try
            {
                var existingStudent = await _studentService.GetStudentByUserIdAsync(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                if (User.IsInRole("Student") && existingStudent.ApplicationUserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    return Forbid();
                }

                await _studentService.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var student = await _studentService.GetStudentByUserIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching student for deletion.");
            }
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }
    }
}
