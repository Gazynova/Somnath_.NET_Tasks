using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentMVC.Services;

namespace StudentMVC.Controllers
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

        public async Task<IActionResult> Enroll(int studentId, int courseId)
        {
            // Ensure the student and course exist before enrolling
            var student = await _studentService.GetStudentByIdAsync(studentId);
            var course = await _courseService.GetCourseByIdAsync(courseId);

            if (student == null || course == null)
            {
                return NotFound();
            }

            await _enrollmentService.EnrollStudentAsync(studentId, courseId);
            return RedirectToAction("Index", "Student");
        }

        public async Task<IActionResult> Withdraw(int studentId, int courseId)
        {
            // Ensure the student and course exist before withdrawing
            var student = await _studentService.GetStudentByIdAsync(studentId);
            var course = await _courseService.GetCourseByIdAsync(courseId);

            if (student == null || course == null)
            {
                return NotFound();
            }

            await _enrollmentService.WithdrawStudentAsync(studentId, courseId);
            return RedirectToAction("Index", "Student");
        }
    }
}
