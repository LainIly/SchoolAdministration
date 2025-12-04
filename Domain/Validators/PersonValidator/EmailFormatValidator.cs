using System.Text.RegularExpressions;

namespace SchoolAdministration.Domain.Validators.PersonValidator
{
    public static class EmailFormatValidator
    {
        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }
    }
}
