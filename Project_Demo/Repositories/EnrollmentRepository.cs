using Microsoft.EntityFrameworkCore;
using Project_Demo.Data;
using Project_Demo.Exceptions;
using Project_Demo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            if (studentId <= 0 || courseId <= 0)
            {
                throw new ValidationException("Invalid student or course ID provided.");
            }

            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student == null)
            {
                throw new NotFoundException($"Student with ID {studentId} not found.");
            }
            if (course == null)
            {
                throw new NotFoundException($"Course with ID {courseId} not found.");
            }

            var existingEnrollment = await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (existingEnrollment)
            {
                throw new ValidationException("Student is already enrolled in this course.");
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task WithdrawStudentAsync(int studentId, int courseId)
        {
            if (studentId <= 0 || courseId <= 0)
            {
                throw new ValidationException("Invalid student or course ID provided.");
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment == null)
            {
                throw new NotFoundException($"Enrollment not found for student ID {studentId} in course ID {courseId}.");
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();

            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            if (courseId <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Include(e => e.Student)
                .ToListAsync();

            return enrollments;
        }
    }
}
