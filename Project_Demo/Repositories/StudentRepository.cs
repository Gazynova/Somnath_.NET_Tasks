using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(s => s.User).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            //if (id <= 0)
            //{
            //    throw new ValidationException("Invalid student ID provided.");
            //}

            var student = await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new NotFoundException($"Student with ID {id} not found.");
            }

            return student;
        }

        public async Task<Student> GetStudentByUserIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ValidationException("User ID cannot be null or empty.");
            }

            var student = await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.ApplicationUserId == userId);

            if (student == null)
            {
                throw new NotFoundException($"Student with User ID {userId} not found.");
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

            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(string id)
        {
            //if (id <= 0)
            //{
            //    throw new ValidationException("Invalid student ID provided.");
            //}

            var student = await _context.Students.FirstOrDefaultAsync(x => x.ApplicationUserId == id);
            if (student == null)
            {
                throw new NotFoundException($"Student with ID {id} not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
