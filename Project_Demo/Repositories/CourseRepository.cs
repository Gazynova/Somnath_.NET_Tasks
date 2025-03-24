using Microsoft.EntityFrameworkCore;
using Project_Demo.Data;
using Project_Demo.Exceptions;
using Project_Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Demo.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new NotFoundException($"Course with ID {id} not found.");
            }

            return course;
        }

        public async Task AddCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ValidationException("Course data cannot be null.");
            }

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ValidationException("Course data cannot be null.");
            }

            var existingCourse = await _context.Courses.FindAsync(course.Id);
            if (existingCourse == null)
            {
                throw new NotFoundException($"Course with ID {course.Id} not found.");
            }

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new NotFoundException($"Course with ID {id} not found.");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
