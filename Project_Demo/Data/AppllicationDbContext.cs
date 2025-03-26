using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Demo.Models;

namespace Project_Demo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  // Use Student instead of ApplicationUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Always call base first for Identity configurations

            // Define the Student - Enrollment Relationship
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)  // Each Enrollment has one Student
                .WithMany(s => s.Enrollments) // Each Student has many Enrollments
                .HasForeignKey(e => e.StudentId) // The FK is StudentId
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete loops

            // Define the Course - Enrollment Relationship
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course) // Each Enrollment has one Course
                .WithMany(c => c.Enrollments) // Each Course has many Enrollments
                .HasForeignKey(e => e.CourseId) // The FK is CourseId
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete enrollments if Course is deleted

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.ApplicationUserId);

        }
    }
}
