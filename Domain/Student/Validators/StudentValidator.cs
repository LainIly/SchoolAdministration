using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.Domain.Student.Validators
{
    public class StudentValidator : IStudentValidator
    {
        private readonly IPersonValidator _personValidator;

        public StudentValidator (IPersonValidator personValidator)
        {
            _personValidator = personValidator;
        }

        public void ValidateProgramFormat(string program)
        {
            //if (program is null)
            //    throw new ArgumentNullException("El programa no puede estar vacio o .", nameof(program));

            if (string.IsNullOrWhiteSpace(program))
                throw new ArgumentException("El programa no puede estar vacio.", nameof(program));

            var stringWithoutSpaces = program.Replace(" ", "");

            if (!stringWithoutSpaces.All(char.IsLetter))
                throw new ArgumentException("Programa solo debe tener letras.", nameof(program));
        }

        public void ValidateAverageFormat (decimal average)
        {
            if (average < 0 || average > 5)
                throw new ArgumentOutOfRangeException("El rango del promedio debe ser entre 0.0 y 5.0.", nameof(average));
        }

        public void ValidateStudent (Students student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            //1. Validacion de reglas de Person
            _personValidator.ValidatePerson(student);

            //2. Validacion de reglas de Student
            ValidateProgramFormat(student.Program);
            ValidateAverageFormat(student.Average);
        }
    }
}
