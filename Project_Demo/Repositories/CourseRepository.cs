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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred while fetching all courses.", ex);
            }
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    throw new NotFoundException($"Course with ID {id} not found.");
                }

                return course;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while fetching the course with ID {id}.", ex);
            }
        }

        public async Task AddCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ValidationException("Course data cannot be null.");
            }

            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred while adding the course.", ex);
            }
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ValidationException("Course data cannot be null.");
            }

            try
            {
                var existingCourse = await _context.Courses.FindAsync(course.Id);
                if (existingCourse == null)
                {
                    throw new NotFoundException($"Course with ID {course.Id} not found.");
                }

                // Updating properties
                existingCourse.CourseName = course.CourseName;
                existingCourse.Description = course.Description;
                existingCourse.Credits = course.Credits;

                _context.Courses.Update(existingCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while updating the course with ID {course.Id}.", ex);
            }
        }

        public async Task DeleteCourseAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    throw new NotFoundException($"Course with ID {id} not found.");
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while deleting the course with ID {id}.", ex);
            }
        }
    }
}
