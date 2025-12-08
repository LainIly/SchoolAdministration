using System.Text.RegularExpressions;

namespace SchoolAdministration.Domain.Validators.PersonValidator
{
    public static class EmailFormatValidator
    {
        public static bool ValidateEmail(string email)
        {
            var validate = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            if (!validate)
                throw new FormatException($"Formato de correo invalido: {email}");
            return true;
        }
    }
}
