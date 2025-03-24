namespace Project_Demo.Models.ViewModels
{
    public class ReportViewModel
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<CourseReport> EnrolledCourses { get; set; }
    }

    public class CourseReport
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string Grade { get; set; }
    }
}
