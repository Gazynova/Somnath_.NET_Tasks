using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Models;


namespace StudentMVC.Repositories
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
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };
            _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task WithdrawStudentAsync(int studentId, int courseId)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Include(e => e.Student)
                .ToListAsync();
        }

        Task<IEnumerable<Enrollment>> IEnrollmentRepository.GetEnrollmentsByStudentIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Enrollment>> IEnrollmentRepository.GetEnrollmentsByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
