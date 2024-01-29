using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe   { set; get; }
    }
}
