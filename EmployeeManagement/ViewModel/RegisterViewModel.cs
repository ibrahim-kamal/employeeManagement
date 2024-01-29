using EmployeeManagement.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [EmailValidationDomain(AllowDomain:"test.com" , ErrorMessage = "Email Domain Not Valid")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and confirm Password do not match")]
        public string confirmPassword { set; get; }
    }
}
