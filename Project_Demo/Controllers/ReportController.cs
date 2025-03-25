using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models.ViewModels;
using Project_Demo.Services;

namespace Project_Demo.Controllers
{
    [Authorize]  // Ensuring only authenticated users can access this controller
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: Report/GenerateReport
        public async Task<IActionResult> GenerateReport(string studentId)
        {
            try
            {
                // Retrieve the report data for the student
                var reportData = await _reportService.GenerateStudentReportAsync(studentId);

                if (reportData == null)
                {
                    return NotFound("No report found for the specified student.");
                }

                // Get the current logged-in user's email
                var currentUserEmail = User.Identity?.Name;

                // Check if the user is authorized to view this report
                if (User.IsInRole("Admin") || User.IsInRole("Teacher") || currentUserEmail == reportData.StudentEmail)
                {
                    // Map the service data to the ReportViewModel
                    var viewModel = new ReportViewModel
                    {
                        StudentName = reportData.StudentName,
                        StudentEmail = reportData.StudentEmail,
                        DateOfBirth = reportData.DateOfBirth,
                        EnrolledCourses = reportData.EnrolledCourses.Select(c => new CourseReport
                        {
                            CourseName = c.CourseName,
                            CourseDescription = c.CourseDescription,
                            Grade = c.Grade
                        }).ToList()
                    };

                    return View(viewModel);  // Return the report view with the mapped model
                }

                // If the user is not authorized, return a 403 Forbidden status
                return Forbid();
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up (optional)
                // _logger.LogError(ex, "Error generating student report");

                return StatusCode(500, "An error occurred while generating the report. Please try again later.");
            }
        }
    }
}
