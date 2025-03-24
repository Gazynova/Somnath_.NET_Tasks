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
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            if (students == null || !students.Any())
            {
                throw new NotFoundException("No students found in the system.");
            }

            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                throw new NotFoundException($"No student found with ID {id}.");
            }

            return student;
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

            await _studentRepository.AddStudentAsync(student);
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

            var existingStudent = await _studentRepository.GetStudentByIdAsync(student.Id);
            if (existingStudent == null)
            {
                throw new NotFoundException($"Cannot update. Student with ID {student.Id} does not exist.");
            }

            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new NotFoundException($"Cannot delete. Student with ID {id} does not exist.");
            }

            await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
