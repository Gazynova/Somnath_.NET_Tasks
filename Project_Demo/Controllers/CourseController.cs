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
                // _logger.LogError(ex, "Error retrieving courses");
                return StatusCode(500, "An error occurred while fetching courses.");
            }
        }

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

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("CourseName,Description,Credits")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,Description,Credits")] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest("Course ID mismatch.");
            }

            if (!ModelState.IsValid)
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
