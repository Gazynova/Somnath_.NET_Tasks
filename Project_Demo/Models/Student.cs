using Microsoft.AspNetCore.Identity;
using Project_Demo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Demo.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string ApplicationUserId { get; set; } // Identity UserId
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

}