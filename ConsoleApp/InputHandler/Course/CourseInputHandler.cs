using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using CE = SchoolAdministration.Domain.Course.Entities;
using SchoolAdministration.Domain.Course.Interfaces;

namespace SchoolAdministration.ConsoleApp.InputHandler.Course
{
    public class CourseInputHandler
    {
        private readonly ConsoleValidationHelper _consoleValidationHelper;
        private readonly ICourseValidator _courseValidator;

        public CourseInputHandler (ConsoleValidationHelper consoleValidationHelper, ICourseValidator courseValidator)
        {
            _consoleValidationHelper = consoleValidationHelper;
            _courseValidator = courseValidator;
        }

        public int InputId()
        {
            return _consoleValidationHelper.ValidateCourseId(_courseValidator);
        }

        public CE.Course InputRegister()
        {
            return new CE.Course(
                _consoleValidationHelper.ValidateCourseName(_courseValidator),
                _consoleValidationHelper.ValidaMaxCourse(_courseValidator)
            );
        }

        public CE.Course InputUpdate()
        {
            return new CE.Course(
                _consoleValidationHelper.ValidateCourseName(_courseValidator),
                _consoleValidationHelper.ValidaMaxCourse(_courseValidator)
            );
        }
    }
}
