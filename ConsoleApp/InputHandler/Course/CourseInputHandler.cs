using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using CE = SchoolAdministration.Domain.Course.Entities;
using SchoolAdministration.Domain.Course.Interfaces;
using SchoolAdministration.Domain.Person.Interfaces;

namespace SchoolAdministration.ConsoleApp.InputHandler.Course
{
    public class CourseInputHandler
    {
        private readonly ConsoleValidationHelper _consoleValidationHelper;
        private readonly ICourseValidator _courseValidator;
        private readonly IPersonValidator _personValidator;

        public CourseInputHandler (ConsoleValidationHelper consoleValidationHelper, ICourseValidator courseValidator, IPersonValidator personValidator)
        {
            _consoleValidationHelper = consoleValidationHelper;
            _courseValidator = courseValidator;
            _personValidator = personValidator;
        }

        public int InputId()
        {
            return _consoleValidationHelper.ValidateCourseId(_courseValidator);
        }

        public CE.Course InputRegister()
        {
            return new CE.Course(
                _consoleValidationHelper.ValidateCourseName(_courseValidator),
                _consoleValidationHelper.ValidaMaxCourse(_courseValidator),
                _consoleValidationHelper.ValidateTeacherId(_personValidator),
                _consoleValidationHelper.ValidateStudentId(_personValidator)
            );
        }

        public CE.Course InputUpdate()
        {
            return new CE.Course(
                _consoleValidationHelper.ValidateCourseName(_courseValidator),
                _consoleValidationHelper.ValidaMaxCourse(_courseValidator),
                _consoleValidationHelper.ValidateTeacherId(_personValidator),
                _consoleValidationHelper.ValidateStudentId(_personValidator)
            );
        }
    }
}
