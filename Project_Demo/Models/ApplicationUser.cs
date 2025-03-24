using Microsoft.AspNetCore.Identity;


namespace Project_Demo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Student Student { get; set; }
    }
}
