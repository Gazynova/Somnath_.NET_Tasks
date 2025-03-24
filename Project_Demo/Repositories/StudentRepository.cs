using Microsoft.EntityFrameworkCore;
using Project_Demo.Data;
using Project_Demo.Exceptions;
using Project_Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Demo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new NotFoundException($"Student with ID {id} not found.");
            }

            return student;
        }

        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ValidationException("Student data cannot be null.");
            }

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ValidationException("Student data cannot be null.");
            }

            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                throw new NotFoundException($"Student with ID {student.Id} not found.");
            }

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Invalid student ID provided.");
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new NotFoundException($"Student with ID {id} not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
