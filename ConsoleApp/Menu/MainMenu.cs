using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Services;
using SchoolAdministration.ConsoleApp.Controllers;
using SchoolAdministration.ConsoleApp.InputHandler;
using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.ConsoleApp.Menu.StudentsMenu;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Students;
using SchoolAdministration.Domain.Infrastructure.Repositories.Students;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Student.Interfaces;
using SchoolAdministration.Domain.Student.Validators;

namespace SchoolAdministration.ConsoleApp.Menu
{
    public class MainMenu
    {
        static void Main(string[] args)
        {
            // Crear dependencias (normalmente luego usarás inyección real)

            IStudentRepository repo = new StudentRepository();
            IPersonValidator pvalidator = new PersonValidator();
            INotificationService notificationService = new NotificationService();
            ConsoleValidationHelper consoleValidationHelper = new ConsoleValidationHelper(notificationService);

            IStudentValidator validator = new StudentValidator(pvalidator);
            StudentInputHandler studentInputHandler = new StudentInputHandler(consoleValidationHelper, pvalidator, validator);
            IStudentService service = new StudentService(repo, validator);
            IStudentController controller = new StudentController(service, notificationService, studentInputHandler);

            // Crear menú
            var studentMenu = new StudentMenu(controller);

            // Ejecutar menú
            studentMenu.ShowMenu();
        }
    }
}
