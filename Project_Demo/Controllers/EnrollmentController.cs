using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Services;

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
            var students = await _studentService.GetAllStudentsAsync();
            var courses = await _courseService.GetAllCoursesAsync();

            var model = new EnrollmentViewModel
            {
                Students = students.ToList(),  // Convert to List<Student> safely
                Courses = courses.ToList()     // Convert to List<Course> safely
            };

            return View(model);
        }

        // POST: Enroll student in a course
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll(EnrollmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Debugging: Ensure the StudentId and CourseId are being passed correctly
                Console.WriteLine($"StudentId: {model.StudentId}, CourseId: {model.CourseId}");

                // Check if IDs are valid before processing
                if (model.StudentId == 0 || model.CourseId == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid student or course selection.");
                    model.Students = (List<Student>)await _studentService.GetAllStudentsAsync();
                    model.Courses = (List<Course>)await _courseService.GetAllCoursesAsync();
                    return View(model);
                }

                await _enrollmentService.EnrollStudentAsync(model.StudentId, model.CourseId);
                return RedirectToAction("Index", "Student");
            }

            // Reload the data in case of an invalid model
            model.Students = (List<Student>)await _studentService.GetAllStudentsAsync();
            model.Courses = (List<Course>)await _courseService.GetAllCoursesAsync();
            return View(model);
        }

        // GET: Withdraw view
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Withdraw()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var courses = await _courseService.GetAllCoursesAsync();

            var model = new EnrollmentViewModel
            {
                Students = students.ToList(),  // Convert to List<Student> safely
                Courses = courses.ToList()     // Convert to List<Course> safely
            };

            return View(model);
        }

        // POST: Withdraw student from a course
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Withdraw(EnrollmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if IDs are valid before processing
                if (model.StudentId == 0 || model.CourseId == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid student or course selection.");
                    model.Students = (List<Student>)await _studentService.GetAllStudentsAsync();
                    model.Courses = (List<Course>)await _courseService.GetAllCoursesAsync();
                    return View(model);
                }

                await _enrollmentService.WithdrawStudentAsync(model.StudentId, model.CourseId);
                return RedirectToAction("Index", "Student");
            }

            // Reload the data in case of an invalid model
            model.Students = (List<Student>)await _studentService.GetAllStudentsAsync();
            model.Courses =     (List<Course>)await _courseService.GetAllCoursesAsync();
            return View(model);
        }
    }
}
