using Project_Demo.Exceptions;
using Project_Demo.Models;
using Project_Demo.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo.Services
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
            if (studentId <= 0 || courseId <= 0)
            {
                throw new ValidationException("Invalid student or course ID provided.");
            }

            await _enrollmentRepository.EnrollStudentAsync(studentId, courseId);
        }

        public async Task WithdrawStudentAsync(int studentId, int courseId)
        {
            if (studentId <= 0 || courseId <= 0)
            {
                throw new ValidationException("Invalid student or course ID provided.");
            }

            await _enrollmentRepository.WithdrawStudentAsync(studentId, courseId);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var enrollments = await _enrollmentRepository.GetEnrollmentsByStudentIdAsync(studentId);

            if (!enrollments.Any())
            {
                throw new NotFoundException($"No enrollments found for student ID {studentId}.");
            }

            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            if (courseId <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var enrollments = await _enrollmentRepository.GetEnrollmentsByCourseIdAsync(courseId);

            if (!enrollments.Any())
            {
                throw new NotFoundException($"No enrollments found for course ID {courseId}.");
            }

            return enrollments;
        }
    }
}
