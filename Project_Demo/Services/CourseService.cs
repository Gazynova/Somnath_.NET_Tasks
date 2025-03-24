using Project_Demo.Exceptions;
using Project_Demo.Models;
using Project_Demo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Demo.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var course = await _courseRepository.GetCourseByIdAsync(id);
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

            await _courseRepository.AddCourseAsync(course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ValidationException("Course data cannot be null.");
            }

            var existingCourse = await _courseRepository.GetCourseByIdAsync(course.Id);
            if (existingCourse == null)
            {
                throw new NotFoundException($"Course with ID {course.Id} not found.");
            }

            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid course ID provided.");
            }

            var existingCourse = await _courseRepository.GetCourseByIdAsync(id);
            if (existingCourse == null)
            {
                throw new NotFoundException($"Course with ID {id} not found.");
            }

            await _courseRepository.DeleteCourseAsync(id);
        }
    }
}
