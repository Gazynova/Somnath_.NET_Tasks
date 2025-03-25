using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Services;
using System;
using System.Threading.Tasks;

namespace Project_Demo.Controllers
{
    [Authorize]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public EnrollmentController(IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Enroll view
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll()
        {
            return View(await PopulateEnrollmentViewModel());
        }

        // POST: Enroll student in a course
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll(EnrollmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await PopulateEnrollmentViewModel());
            }

            try
            {
                if (model.StudentId == null || model.CourseId == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid student or course selection.");
                    return View(await PopulateEnrollmentViewModel());
                }

                await _enrollmentService.EnrollStudentAsync(model.StudentId, model.CourseId);
                return RedirectToAction("Index", "Student");
            }
            catch (Exception ex)
            {
                // Log error (optional)
                return StatusCode(500, "An error occurred while enrolling the student.");
            }
        }

        // GET: Withdraw view
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Withdraw()
        {
            return View(await PopulateEnrollmentViewModel());
        }

        // POST: Withdraw student from a course
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Withdraw(EnrollmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await PopulateEnrollmentViewModel());
            }

            try
            {
                // Check if IDs are valid before processing
                if (model.StudentId == null || model.CourseId == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid student or course selection.");
                    return View(await PopulateEnrollmentViewModel());
                }

                await _enrollmentService.WithdrawStudentAsync(model.StudentId, model.CourseId);
                return RedirectToAction("Index", "Student");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while withdrawing the student.");
            }
        }

        private async Task<EnrollmentViewModel> PopulateEnrollmentViewModel()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var courses = await _courseService.GetAllCoursesAsync();

            return new EnrollmentViewModel
            {
                Students = students.ToList(),
                Courses = courses.ToList()
            };
        }
    }
}
