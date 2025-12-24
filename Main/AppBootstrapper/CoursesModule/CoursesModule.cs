using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Interfaces.Course;
using SchoolAdministration.Application.Interfaces.Student;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.Application.Services.Course;
using SchoolAdministration.Application.Services.Student;
using SchoolAdministration.Application.Services.Teacher;
using SchoolAdministration.ConsoleApp.Controllers.Course;
using SchoolAdministration.ConsoleApp.InputHandler.Course;
using SchoolAdministration.ConsoleApp.InputHandler.Helper;
using SchoolAdministration.Domain.Course.Interfaces;
using SchoolAdministration.Domain.Course.Validators;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Courses;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Students;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers;
using SchoolAdministration.Domain.Infrastructure.Repositories.Courses;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Student.Interfaces;
using SchoolAdministration.Domain.Student.Validators;
using SchoolAdministration.Domain.Teacher.Interfaces;
using SchoolAdministration.Domain.Teacher.Validators;

namespace SchoolAdministration.Main.AppBootstrapper.CoursesModule
{
    public class CoursesModule
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeachersRepository _teachersRepository;
        private readonly IStudentRepository _studentRepository;

        public CoursesModule(ICourseRepository courseRepository, ITeachersRepository teachersRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _teachersRepository = teachersRepository;
            _studentRepository = studentRepository;
        }

        public ICourseController Build(INotificationService notificationService)
        {
            ICourseValidator courseValidator = new CourseValidator();
            IPersonValidator personValidator = new PersonValidator();
            ITeacherValidator teacherValidator = new TeacherValidator(personValidator);
            ITeacherService teacherService = new TeacherService(_teachersRepository, teacherValidator);
            IStudentValidator studentValidator = new StudentValidator(personValidator);
            IStudentService studentService = new StudentService(_studentRepository, studentValidator);

            var helper = new ConsoleValidationHelper(notificationService);
            var inputHelper = new CourseInputHandler(helper, courseValidator, personValidator);

            ICourseService courseService = new CourseService(_courseRepository, courseValidator, _teachersRepository);

            return new CourseController(courseService, notificationService, inputHelper, teacherService, studentService);
        }
    }
}
