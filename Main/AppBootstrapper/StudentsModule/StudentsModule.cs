using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Student;
using SchoolAdministration.Application.Services.Student;
using SchoolAdministration.ConsoleApp.Controllers.Student;
using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.ConsoleApp.InputHandler.StudentInput;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Students;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Student.Interfaces;
using SchoolAdministration.Domain.Student.Validators;

namespace SchoolAdministration.Main.AppBootstrapper.StudentsModule
{
    public class StudentsModule
    {
        private readonly IStudentRepository _repository;

        public StudentsModule(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IStudentController Build(INotificationService notificationService)
        {
            IPersonValidator personValidator = new PersonValidator();
            IStudentValidator studentValidator = new StudentValidator(personValidator);

            var helper = new ConsoleValidationHelper(notificationService);
            var inputHandler = new StudentInputHandler(
                helper,
                personValidator,
                studentValidator
            );

            IStudentService service =
                new StudentService(_repository, studentValidator);

            return new StudentController(
                service,
                notificationService,
                inputHandler
            );
        }
    }

}
