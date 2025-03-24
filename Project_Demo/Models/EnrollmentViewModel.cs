namespace Project_Demo.Models
{
    public class EnrollmentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<Student> Students { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
