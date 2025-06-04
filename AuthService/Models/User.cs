using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class User: IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public User() : base()
        {
            
        }
    }
}
