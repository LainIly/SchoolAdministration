using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Teacher.Interfaces;
using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.ConsoleApp.InputHandler.TeacherInput
{
    public class TeacherInputHandler
    {
        private readonly ConsoleValidationHelper _consoleValidationHelper;
        private readonly IPersonValidator _personValidator;
        private readonly ITeacherValidator _teacherValidator;

        public TeacherInputHandler(ConsoleValidationHelper consoleValidationHelper, IPersonValidator personValidator, ITeacherValidator teacherValidator)
        {
            _consoleValidationHelper = consoleValidationHelper;
            _personValidator = personValidator;
            _teacherValidator = teacherValidator;
        }

        public int InputId()
        {
            return _consoleValidationHelper.ValidateId(_personValidator);
        }

        public TE.Teacher InputRegister()
        {
            return new TE.Teacher(
                _consoleValidationHelper.ValidateName(_personValidator),
                _consoleValidationHelper.ValidateEmail(_personValidator),
                _consoleValidationHelper.ValidateTeacherAge(_teacherValidator),
                _consoleValidationHelper.ValidateDegree(_teacherValidator),
                _consoleValidationHelper.ValidateYearsE(_teacherValidator)
            );
        }

        public TE.Teacher InputUpdate()
        {
            return new TE.Teacher(
                _consoleValidationHelper.ValidateName(_personValidator),
                _consoleValidationHelper.ValidateEmail(_personValidator),
                _consoleValidationHelper.ValidateTeacherAge(_teacherValidator),
                _consoleValidationHelper.ValidateDegree(_teacherValidator),
                _consoleValidationHelper.ValidateYearsE(_teacherValidator)
            );
        }
    }
}
