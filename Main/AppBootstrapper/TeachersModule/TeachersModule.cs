using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.Application.Services.Teacher;
using SchoolAdministration.ConsoleApp.Controllers.Teacher;
using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.ConsoleApp.InputHandler.TeacherInput;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Teacher.Interfaces;
using SchoolAdministration.Domain.Teacher.Validators;

namespace SchoolAdministration.Main.AppBootstrapper.TeachersModule
{
    public class TeachersModule
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersModule(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        public TeacherController Build (INotificationService notificationService)
        {
            IPersonValidator personValidator = new PersonValidator();
            ITeacherValidator teacherValidator = new TeacherValidator(personValidator);

            var helper = new ConsoleValidationHelper(notificationService);
            var inputHandler = new TeacherInputHandler(helper, personValidator, teacherValidator);

            ITeacherService service = new TeacherService(_teachersRepository, teacherValidator);

            return new TeacherController(service, inputHandler, notificationService);
        }
    }
}
