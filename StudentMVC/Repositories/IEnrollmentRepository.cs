using StudentMVC.Models;

namespace StudentMVC.Repositories
{

    public interface IEnrollmentRepository
    {
        Task EnrollStudentAsync(int studentId, int courseId);
        Task WithdrawStudentAsync(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
    }


}
