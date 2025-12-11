using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.ConsoleApp.InputHandler.TeacherInput;
using SchoolAdministration.ConsoleApp.Printers.TeacherPrinter;
using SchoolAdministration.Domain.Teacher.Interfaces;

namespace SchoolAdministration.ConsoleApp.Controllers.Teacher
{
    public class TeacherController : ITeacherController
    {
        private readonly ITeacherService _teacherService;
        private readonly TeacherInputHandler _teacherInputHandler;
        private readonly INotificationService _notificationService;

        public TeacherController(ITeacherService teacherService, TeacherInputHandler teacherInputHandler, INotificationService notificationService)
        {
            _teacherService = teacherService;
            _teacherInputHandler = teacherInputHandler;
            _notificationService = notificationService;
        }

        public void CreateTeacher ()
        {
            try
            {
                var createTeacher = _teacherInputHandler.InputRegister();
                _teacherService.CreateTeacher(createTeacher);

                _notificationService.Success("Profesor creado correctamente.");
                TeachersPrinter.PrintTeacher(createTeacher);
            } catch (Exception ex)
            {
                _notificationService.Error(ex.Message);
            }
        }

        public void GetTeacherById()
        {
            int id = _teacherInputHandler.InputId();

            try
            {
                var teacher = _teacherService.GetById(id);

                _notificationService.Success("==== Profesor encontrado ====");
                TeachersPrinter.PrintTeacher(teacher);

            } catch (KeyNotFoundException ex)
            {
                _notificationService.Error(ex.Message);
            }
        }

        public void UpdateTeacher ()
        {
            try
            {
                int id = _teacherInputHandler.InputId();
                var existing = _teacherService.GetById(id);

                if (existing is null)
                {
                    _notificationService.Error($"No existe un profesor con Id {id}.");
                    return;
                }

                //Agregar el printer para mostrar el profesor encontrado.

                _notificationService.Warning("Ingrese los nuevos datos.");
                var updateData = _teacherInputHandler.InputUpdate();

                updateData.SetId(existing.Id);

                _teacherService.UpdateTeacher(updateData);
                _notificationService.Success("Profesor actualizado correctamente.");

            } catch (KeyNotFoundException ex)
            {
                _notificationService.Error(ex.Message);
            }
        }

        public void DeleteTeacher()
        {
            int id = _teacherInputHandler.InputId();
            bool deleted = _teacherService.DeleteTeacher(id);

            if (deleted)
            {
                _notificationService.Success("Teacher eliminado correctamente.");
            } else
            {
                _notificationService.Error("No se pudo eliminar al profesor.");
            }
        }

        public void GetAllTeachers()
        {
            var teachers = _teacherService.GetAll();

            if (teachers.Count == 0)
            {
                _notificationService.Error("No existen profesores registrados.");
                return;
            }

            foreach (var t in teachers)
            {
                TeachersPrinter.PrintTeacher(t);
            }
        }
    }
}
