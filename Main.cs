using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Application.Services;
using SchoolAdministration.ConsoleApp.Menu;
using SchoolAdministration.ConsoleApp.Menu.CoursesMenu;
using SchoolAdministration.ConsoleApp.Menu.StudentsMenu;
using SchoolAdministration.ConsoleApp.Menu.TeachersMenu;
using SchoolAdministration.Domain.Infrastructure.Repositories.Courses;
using SchoolAdministration.Domain.Infrastructure.Repositories.Students;
using SchoolAdministration.Domain.Infrastructure.Repositories.Teachers;
using SchoolAdministration.Main.AppBootstrapper.CoursesModule;
using SchoolAdministration.Main.AppBootstrapper.StudentsModule;
using SchoolAdministration.Main.AppBootstrapper.TeachersModule;

namespace SchoolAdministration.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INotificationService notificationService = new NotificationService();

            var teacherRepository = new TeacherRepository();
            var studentRepository = new StudentRepository();
            var courseRepository = new CourseRepository();

            var studentsModule = new StudentsModule(studentRepository);
            var teachersModule = new TeachersModule(teacherRepository);
            var coursesModule = new CoursesModule(courseRepository, teacherRepository, studentRepository);

            var studentController = studentsModule.Build(notificationService);
            var teacherController = teachersModule.Build(notificationService);
            var courseController = coursesModule.Build(notificationService);

            var studentMenu = new StudentMenu(studentController);
            var teacherMenu = new TeacherMenu(teacherController);
            var courseMenu = new CourseMenu(courseController);

            var mainMenu = new MainMenu(studentMenu, teacherMenu, courseMenu);
            mainMenu.Show();
        }
    }
}
