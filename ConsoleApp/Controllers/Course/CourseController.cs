using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Course;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.ConsoleApp.InputHandler.Course;
using SchoolAdministration.ConsoleApp.Printers.CoursePrinter;
using SchoolAdministration.ConsoleApp.Printers.TeacherPrinter;
using SchoolAdministration.Domain.Course.Interfaces;

namespace SchoolAdministration.ConsoleApp.Controllers.Course
{
    public class CourseController : ICourseController
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly INotificationService _notificationService;
        private readonly CourseInputHandler _courseInputHandler;

        public CourseController(ICourseService courseService, INotificationService notificationService, CourseInputHandler courseInputHandler, ITeacherService teacherService)
        {
            _courseService = courseService;
            _notificationService = notificationService;
            _courseInputHandler = courseInputHandler;
            _teacherService = teacherService;
        }

        public void CreateCourse()
        {
            try
            {
                var createCourse = _courseInputHandler.InputRegister();
                _courseService.CreateCourse(createCourse);
                var teacher = _teacherService.GetById(createCourse.TeacherId);

                _notificationService.Success("Curso creado correctamente.");
                CoursesPrinter.PrintCourse(createCourse, teacher);
                //TeachersPrinter.PrintTeacher(teacher);
            }
            catch (Exception ex)
            {
                _notificationService.Error(ex.Message);
            }
        }

        public void GetCourseById()
        {
            int id = _courseInputHandler.InputId();

            try
            {
                var course = _courseService.GetById(id);
                var teacher = _teacherService.GetById(course.TeacherId);
                _notificationService.Success("==== Curso encontrado ====");
                CoursesPrinter.PrintCourse(course, teacher);
            }
            catch (KeyNotFoundException)
            {
                _notificationService.Error($"No existe un curso con Id {id}");
            }
        }

        public void UpdateCourse()
        {
            try
            {
                int id = _courseInputHandler.InputId();
                var existing = _courseService.GetById(id);

                if (existing is null)
                {
                    _notificationService.Error($"No existe un curso con Id {id}");
                    return;
                }

                _notificationService.Warning("Ingrese los nuevos datos:");
                var updateData = _courseInputHandler.InputUpdate();

                updateData.SetId(existing.Id);

                _courseService.UpdateCourse(updateData);
                _notificationService.Success("Curso actualizado correctamente.");
            }
            catch (KeyNotFoundException ex)
            {
                _notificationService.Error(ex.Message);
            }
        }
        
        public void DeleteCourse ()
        {
            int id = _courseInputHandler.InputId();

            bool deleted = _courseService.DeleteCourse(id);

            if (deleted)
            {
                _notificationService.Success("Curso eliminado correctamente.");
            }
            else
            {
                _notificationService.Error("No se pudo eliminar el curso.");
            }
        }

        public void GetAllCourses ()
        {
            var courses = _courseService.GetAll();
            
            if (courses.Count == 0)
            {
                _notificationService.Error("No existen cursos registrados.");
                return;
            }

            foreach (var c in courses)
            {
                //CoursesPrinter.PrintCourse(c);
            }
        }
    }
}
