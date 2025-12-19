using SchoolAdministration.ConsoleApp.Menu.CoursesMenu;
using SchoolAdministration.ConsoleApp.Menu.StudentsMenu;
using SchoolAdministration.ConsoleApp.Menu.TeachersMenu;

namespace SchoolAdministration.ConsoleApp.Menu
{
    public class MainMenu
    {
        private readonly StudentMenu _studentMenu;
        private readonly TeacherMenu _teacherMenu;
        private readonly CourseMenu _courseMenu;

        public MainMenu(
            StudentMenu studentMenu,
            TeacherMenu teacherMenu,
            CourseMenu courseMenu
        )
        {
            _studentMenu = studentMenu;
            _teacherMenu = teacherMenu;
            _courseMenu = courseMenu;
        }

        public void Show()
        {
            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA DE ADMINISTRACIÓN ESCOLAR =====");
                Console.WriteLine("1. Gestión de estudiantes");
                Console.WriteLine("2. Gestión de profesores");
                Console.WriteLine("3. Gestión de cursos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        _studentMenu.ShowMenu();
                        break;

                    case 2:
                        _teacherMenu.ShowMenu();
                        break;

                    case 3:
                        _courseMenu.ShowMenu();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (option != 5);
        }
    }


}
