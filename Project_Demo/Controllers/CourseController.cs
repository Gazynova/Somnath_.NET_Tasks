using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Services;
using System;
using System.Threading.Tasks;

namespace Project_Demo.Controllers
{
    [Authorize] // Ensure only authenticated users can access this controller
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Index
        [Authorize(Roles = "Student, Teacher")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();
                return View(courses);
            }
            catch (Exception ex)
            {
                // Log error (optional)
                return StatusCode(500, "An error occurred while fetching courses.");
            }
        }

        // GET: Details
        [Authorize(Roles = "Student, Teacher")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                {
                    return NotFound("Course not found.");
                }
                return View(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving course details.");
            }
        }

        // GET: Create
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("CourseName,Description,Credits")] Course course)
        {
            try
            {
                await _courseService.AddCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the course.");
            }
        }

        // GET: Edit
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                {
                    return NotFound("Course not found.");
                }
                return View(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving course details.");
            }
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,Description,Credits")] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest("Course ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                return View(course);
            }

            try
            {
                await _courseService.UpdateCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the course.");
            }
        }

        // GET: Delete
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                {
                    return NotFound("Course not found.");
                }
                return View(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving course details.");
            }
        }

        // POST: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}
