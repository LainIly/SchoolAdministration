using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.ConsoleApp.Printers.StudentPrinter;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.ConsoleApp.Controllers
{
    public class StudentController : IStudentController
    {
        private readonly IStudentService _studentService;
        private readonly INotificationService _notificationService;

        public StudentController(IStudentService studentService, INotificationService notificationService)
        {
            _studentService = studentService;
            _notificationService = notificationService;
        }

        public void CreateStudent()
        {
            try
            {
                var createStudent = StudentInputHandler.GetData();
                _studentService.CreateStudent(createStudent);

                _notificationService.Success("Estudiante creado correctamente.");
            }
            catch (Exception ex)
            {
                _notificationService.Error(ex.Message);
                // el ciclo continúa, vuelve a pedir datos
            }

        }

        public void GetStudentById()
        {
            int id = StudentInputHandler.GetId();

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
            int id = StudentInputHandler.GetId();
            var existing = _studentService.GetById(id);

            _notificationService.Warning("Ingrese los nuevos datos:");
            var updatedData = StudentInputHandler.GetUpdatedStudentData();

            //verificamos que el Id no cambie.

            updatedData.Id = existing.Id;

            _studentService.UpdateStudent(updatedData);

            _notificationService.Success("Estudiante actualizado correctamente.");
        }

        public void DeleteStudent()
        {
            int id = StudentInputHandler.GetId();

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
