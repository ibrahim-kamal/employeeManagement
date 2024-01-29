using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    public class EmailValidationDomainAttribute : ValidationAttribute
    {
        string _AllowDomain;
        public EmailValidationDomainAttribute(string AllowDomain)
        {
            _AllowDomain = AllowDomain;
        }

        public override bool IsValid(object? value)
        {
            string[] strings = value.ToString().Split("@");
            return strings[0].ToUpper() == _AllowDomain.ToUpper();
        }
    }
}
