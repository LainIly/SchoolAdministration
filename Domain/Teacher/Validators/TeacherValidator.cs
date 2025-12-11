using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Teacher.Interfaces;
using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.Domain.Teacher.Validators
{
    public class TeacherValidator : ITeacherValidator
    {
        private readonly IPersonValidator _personValidator;

        public TeacherValidator(IPersonValidator personValidator)
        {
            _personValidator = personValidator;
        }

        public void ValidateTeacherAge(int age)
        {
            if (age < 25 || age > 60)
                throw new ArgumentOutOfRangeException("La edad debe ser mayor a 25 y menor a 60 an/os.", nameof(age));
        }

        public void ValidateDegreeFormat (string degree)
        {
            if (string.IsNullOrWhiteSpace(degree))
                throw new ArgumentException("Especialidad no puede estar vacia.", nameof(degree));

            var stringWithoutSpaces = degree.Replace(" ", "");

            if (!stringWithoutSpaces.All(char.IsLetter))
                throw new ArgumentException("Especialialidad solo debe tener letras.", nameof(degree));
        }

        public void ValidateYearsEFormat(int yearsE)
        {
            if (yearsE < 2)
                throw new ArgumentOutOfRangeException("La experiencia debe ser mayor a 2 an/os.", nameof(yearsE));
        }

        public void ValidateTeacher(TE.Teacher teacher)
        {
            if (teacher is null)
                throw new ArgumentNullException(nameof(teacher));

            _personValidator.ValidatePerson(teacher);

            ValidateDegreeFormat(teacher.Degree);
            ValidateYearsEFormat(teacher.YearsE);
            ValidateTeacherAge(teacher.Age);
        }
    }
}
