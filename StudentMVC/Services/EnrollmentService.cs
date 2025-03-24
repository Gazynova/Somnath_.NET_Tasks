using StudentMVC.Models;
using StudentMVC.Repositories;

namespace StudentMVC.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            await _enrollmentRepository.EnrollStudentAsync(studentId, courseId);
        }

        public async Task WithdrawStudentAsync(int studentId, int courseId)
        {
            await _enrollmentRepository.WithdrawStudentAsync(studentId, courseId);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            return await _enrollmentRepository.GetEnrollmentsByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            return await _enrollmentRepository.GetEnrollmentsByCourseIdAsync(courseId);
        }




    }
}
