using Microsoft.EntityFrameworkCore;
using Project_Demo.Data;
using Project_Demo.Exceptions;
using Project_Demo.Models.ViewModels;
using Project_Demo.Services;
using System.Linq;
using System.Threading.Tasks;

public class ReportService : IReportService
{
    private readonly ApplicationDbContext _context;

    public ReportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReportViewModel> GenerateStudentReportAsync(string studentId)
    {
        //if (studentId <= 0)
        //{
        //    throw new ValidationException("Invalid student ID provided.");
        //}

        var studentReport = await _context.Students
            .Where(s => s.ApplicationUserId == studentId)
            .Select(s => new ReportViewModel
            {
                StudentName = s.FirstName + " " + s.LastName,
                StudentEmail = s.Email,
                DateOfBirth = s.DateOfBirth,
                EnrolledCourses = s.Enrollments.Select(e => new CourseReport
                {
                    CourseName = e.Course.CourseName,
                    CourseDescription = e.Course.Description,
                    Grade = e.Grade
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (studentReport == null)
        {
            throw new NotFoundException($"No report found for student ID {studentId}.");
        }

        return studentReport;
    }
}
