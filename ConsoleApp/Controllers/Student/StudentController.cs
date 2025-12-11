using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Student;
using SchoolAdministration.ConsoleApp.InputHandler.StudentInput;
using SchoolAdministration.ConsoleApp.Printers.StudentPrinter;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.ConsoleApp.Controllers.Student
{
    public class StudentController : IStudentController
    {
        private readonly IStudentService _studentService;
        private readonly INotificationService _notificationService;
        private readonly StudentInputHandler _studentInputHandler;

        public StudentController(IStudentService studentService, INotificationService notificationService, StudentInputHandler studentInputHandler)
        {
            _studentService = studentService;
            _notificationService = notificationService;
            _studentInputHandler = studentInputHandler;
        }

        public void CreateStudent()
        {
            try
            {
                var createStudent = _studentInputHandler.InputRegister();
                _studentService.CreateStudent(createStudent);

                _notificationService.Success("Estudiante creado correctamente.");
                StudentsPrinter.PrintStudent(createStudent);
            }
            catch (Exception ex)
            {
                _notificationService.Error(ex.Message);
                // el ciclo continúa, vuelve a pedir datos
            }
        }

        public void GetStudentById()
        {
            int id = _studentInputHandler.InputId();

            try
            {
                var student = _studentService.GetById(id);

                _notificationService.Success(" ==== Estudiante encontrado ====");
                StudentsPrinter.PrintStudent(student);
            }
            catch (KeyNotFoundException)
            {
                _notificationService.Error($"No existe un estudiante con ID {id}.");
            }
        }

        public void UpdateStudent()
        {
            try
            {
                int id = _studentInputHandler.InputId();
                var existing = _studentService.GetById(id);

                if (existing == null)
                {
                    _notificationService.Error($"No existe un estudiante con Id {id}.");
                    return;
                }

                _notificationService.Warning("Ingrese los nuevos datos:");
                var updatedData = _studentInputHandler.InputUpdate();

                updatedData.SetId(existing.Id);  // Mantenemos el mismo Id

                _studentService.UpdateStudent(updatedData);
                _notificationService.Success("Estudiante actualizado correctamente.");
            } catch (KeyNotFoundException ex)
            {
                _notificationService.Error(ex.Message);
            }
        }

        public void DeleteStudent()
        {
            int id = _studentInputHandler.InputId();

            bool deleted = _studentService.DeleteStudent(id);

            if (deleted)
                _notificationService.Success("Estudiante eliminado correctamente.");
            else
                _notificationService.Error("No se pudo eliminar el estudiante.");
        }

        public void GetAllStudents()
        {
            var students = _studentService.GetAll();

            if (students.Count == 0)
            {
                _notificationService.Error("No existen estudiantes registrados.");
                return;
            }

            foreach (var s in students)
            {
                StudentsPrinter.PrintStudent(s);
            }
        }
    }
}
