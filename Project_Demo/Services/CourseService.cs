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
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await _courseRepository.GetAllCoursesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching courses.", ex);
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
                var course = await _courseRepository.GetCourseByIdAsync(id);
                if (course == null)
                {
                    throw new NotFoundException($"Course with ID {id} not found.");
                }

                return course;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching the course with ID {id}.", ex);
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
                await _courseRepository.AddCourseAsync(course);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while adding the course.", ex);
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
                var existingCourse = await _courseRepository.GetCourseByIdAsync(course.Id);
                if (existingCourse == null)
                {
                    throw new NotFoundException($"Course with ID {course.Id} not found.");
                }

                await _courseRepository.UpdateCourseAsync(course);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating the course with ID {course.Id}.", ex);
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
                var existingCourse = await _courseRepository.GetCourseByIdAsync(id);
                if (existingCourse == null)
                {
                    throw new NotFoundException($"Course with ID {id} not found.");
                }

                await _courseRepository.DeleteCourseAsync(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting the course with ID {id}.", ex);
            }
        }
    }
}
