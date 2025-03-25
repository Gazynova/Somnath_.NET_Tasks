using Project_Demo.Models;

namespace Project_Demo.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        //Task<Student> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
        Task<Student> GetStudentByUserIdAsync(string userId);
    }
}
