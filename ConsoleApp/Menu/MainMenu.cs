using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Student;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.Application.Services;
using SchoolAdministration.Application.Services.Student;
using SchoolAdministration.Application.Services.Teacher;
using SchoolAdministration.ConsoleApp.Controllers.Student;
using SchoolAdministration.ConsoleApp.Controllers.Teacher;
using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.ConsoleApp.InputHandler.StudentInput;
using SchoolAdministration.ConsoleApp.InputHandler.TeacherInput;
using SchoolAdministration.ConsoleApp.Menu.StudentsMenu;
using SchoolAdministration.ConsoleApp.Menu.TeachersMenu;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Students;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers;
using SchoolAdministration.Domain.Infrastructure.Repositories.Students;
using SchoolAdministration.Domain.Infrastructure.Repositories.Teachers;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Student.Interfaces;
using SchoolAdministration.Domain.Student.Validators;
using SchoolAdministration.Domain.Teacher.Interfaces;
using SchoolAdministration.Domain.Teacher.Validators;

namespace SchoolAdministration.ConsoleApp.Menu
{
    public class MainMenu
    {
        static void Main(string[] args)
        {
            // Crear dependencias (normalmente luego usarás inyección real)

            IStudentRepository repo = new StudentRepository();
            ITeachersRepository teacherRepo = new TeacherRepository();
            IPersonValidator pvalidator = new PersonValidator();
            INotificationService notificationService = new NotificationService();
            ConsoleValidationHelper consoleValidationHelper = new ConsoleValidationHelper(notificationService);

            //Students

            IStudentValidator validator = new StudentValidator(pvalidator);
            StudentInputHandler studentInputHandler = new StudentInputHandler(consoleValidationHelper, pvalidator, validator);
            IStudentService service = new StudentService(repo, validator);
            IStudentController controller = new StudentController(service, notificationService, studentInputHandler);

            //Teachers

            ITeacherValidator teacherValidator = new TeacherValidator(pvalidator);
            TeacherInputHandler teacherInputHandler = new TeacherInputHandler(consoleValidationHelper, pvalidator, teacherValidator);
            ITeacherService teacherService = new TeacherService(teacherRepo, teacherValidator);
            ITeacherController teacherController = new TeacherController(teacherService, teacherInputHandler, notificationService);

            // Crear menú
            //var studentMenu = new StudentMenu(controller);
            var teacherMenu = new TeacherMenu(teacherController);

            // Ejecutar menú
            //studentMenu.ShowMenu();
            teacherMenu.ShowMenu();
        }
    }
}
