using Microsoft.AspNetCore.Identity;

namespace JobNetCore6.Entities
{
    public class AppUser:IdentityUser
    {
        public string? Name { get; set; }
     
        public string? Password { get; set; }

        public string? AccountType { get; set; }

        public string? UserRole { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
