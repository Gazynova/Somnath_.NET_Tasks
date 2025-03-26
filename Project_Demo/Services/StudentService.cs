using Project_Demo.Exceptions;
using Project_Demo.Models;
using Project_Demo.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllStudentsAsync();

                if (students == null || !students.Any())
                {
                    throw new NotFoundException("No students found in the system.");
                }

                return students;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while retrieving students.", ex);
            }
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ValidationException("Student ID cannot be null or empty.");
            }

            try
            {
                var student = await _studentRepository.GetStudentByUserIdAsync(id);

                if (student == null)
                {
                    throw new NotFoundException($"No student found with ID {id}.");
                }

                return student;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error occurred while retrieving the student with ID {id}.", ex);
            }
        }

        public async Task<Student> GetStudentByUserIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ValidationException("User ID cannot be null or empty.");
            }

            try
            {
                var student = await _studentRepository.GetStudentByUserIdAsync(userId);

                if (student == null)
                {
                    throw new NotFoundException($"No student found with User ID {userId}.");
                }

                return student;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error occurred while retrieving the student with User ID {userId}.", ex);
            }
        }

        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ValidationException("Student data cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
            {
                throw new ValidationException("Student must have a first and last name.");
            }

            try
            {
                await _studentRepository.AddStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while adding the student.", ex);
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ValidationException("Student data cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
            {
                throw new ValidationException("Student must have a first and last name.");
            }

            try
            {
                var existingStudent = await _studentRepository.GetStudentByUserIdAsync(student.ApplicationUserId);
                if (existingStudent == null)
                {
                    throw new NotFoundException($"Cannot update. Student with User ID {student.ApplicationUserId} does not exist.");
                }

                await _studentRepository.UpdateStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error occurred while updating the student with ID {student.Id}.", ex);
            }
        }

        public async Task DeleteStudentAsync(string applicationUserId)
        {
            if (string.IsNullOrEmpty(applicationUserId))
            {
                throw new ValidationException("User ID cannot be null or empty.");
            }

            try
            {
                var student = await _studentRepository.GetStudentByUserIdAsync(applicationUserId);
                if (student == null)
                {
                    throw new NotFoundException($"Cannot delete. Student with User ID {applicationUserId} does not exist.");
                }

                await _studentRepository.DeleteStudentAsync(applicationUserId);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error occurred while deleting the student with User ID {applicationUserId}.", ex);
            }
        }
    }
}
