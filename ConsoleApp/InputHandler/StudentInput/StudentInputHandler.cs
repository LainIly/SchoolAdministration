using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.ConsoleApp.InputHandler.StudentInput
{
    public class StudentInputHandler
    {
        private readonly ConsoleValidationHelper _consoleValidationHelper;
        private readonly IPersonValidator _personValidator;
        private readonly IStudentValidator _studentValidator;
        public StudentInputHandler(ConsoleValidationHelper consoleValidationHelper,
            IPersonValidator personValidator, IStudentValidator studentValidator)
        {
            _consoleValidationHelper = consoleValidationHelper;
            _personValidator = personValidator;
            _studentValidator = studentValidator;
        }

        public int InputId()
        {
            return _consoleValidationHelper.ValidateId(_personValidator);
        } //Es correcto, no tocar mas.

        public Students InputRegister()
        {
            return new Students(
                _consoleValidationHelper.ValidateName(_personValidator),
                _consoleValidationHelper.ValidateEmail(_personValidator),
                _consoleValidationHelper.ValidateAge(_personValidator),
                _consoleValidationHelper.ValidateProgram(_studentValidator),
                _consoleValidationHelper.ValidateAverage(_studentValidator)
            );
        }

        public Students InputUpdate()
        {
            return new Students(
                _consoleValidationHelper.ValidateName(_personValidator),
                _consoleValidationHelper.ValidateEmail(_personValidator),
                _consoleValidationHelper.ValidateAge(_personValidator),
                _consoleValidationHelper.ValidateProgram(_studentValidator),
                _consoleValidationHelper.ValidateAverage(_studentValidator)
            );
        }
    }
}
