using Project_Demo.Models.ViewModels;

namespace Project_Demo.Services
{
    public interface IReportService
    {
        Task<ReportViewModel> GenerateStudentReportAsync(string studentId);

    }
}
