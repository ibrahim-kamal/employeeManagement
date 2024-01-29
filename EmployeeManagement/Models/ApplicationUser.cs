using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool gender { get; set; }
    }
}
