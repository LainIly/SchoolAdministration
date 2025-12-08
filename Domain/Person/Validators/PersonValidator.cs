using SchoolAdministration.Domain.Person.Entities;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Validators.PersonValidator;

namespace SchoolAdministration.Domain.Person.Validators
{
    public class PersonValidator : IPersonValidator
    {
        public void ValidateIdFormat(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Id debe ser mayor a 0.", nameof(id));
        }

        public void ValidateNameFormat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacio.", nameof(name));

            var nameWithoutSpaces = name.Replace(" ", "");

            if (!nameWithoutSpaces.All(char.IsLetter))
                throw new ArgumentException("El nombre solo puede contener letras y espacios.", nameof(name));
        }

        public void ValidateEmailFormat(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("El correo no puede estar vacio.", nameof(email));

            EmailFormatValidator.ValidateEmail(email);
        }

        public void ValidateAgeFormat(int age)
        {
            if (age < 5 || age > 25)
                throw new ArgumentOutOfRangeException("La edad debe ser mayor a 5 y menor a 25 an/os.", nameof(age));
        }

        public void ValidatePerson(People people)
        {
            ValidateNameFormat(people.Name);
            ValidateEmailFormat(people.Email);
            ValidateAgeFormat(people.Age);
        }
    }
}
