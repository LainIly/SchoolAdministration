using System.Text.RegularExpressions;

namespace SchoolAdministration.Domain.Validators.PersonValidator
{
    public static class EmailFormatValidator
    {
        public static void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                throw new ArgumentException("Formato de correo invalido.");
        }
    }
}
