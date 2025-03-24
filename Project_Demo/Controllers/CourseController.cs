using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Services;

namespace Project_Demo.Controllers
{

    public class CourseController : Controller
    {
        readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize(Roles = "Student, Teacher")]
        // GET: Course
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }

        [Authorize(Roles = "Student, Teacher")]
        // GET: Course/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        [Authorize(Roles = "Student, Teacher")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]

        public async Task<IActionResult> Create([Bind("CourseName,Description,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        [Authorize(Roles = "Teacher")]

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,Description,Credits")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _courseService.UpdateCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "Teacher")]

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
