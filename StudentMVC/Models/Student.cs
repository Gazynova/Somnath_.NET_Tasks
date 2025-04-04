﻿namespace StudentMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Enrollment> Enrollments
        {
            get; set;
        }
    }
}
