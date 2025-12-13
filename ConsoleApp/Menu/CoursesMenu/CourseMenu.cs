using SchoolAdministration.Domain.Course.Interfaces;

namespace SchoolAdministration.ConsoleApp.Menu.CoursesMenu
{
    public class CourseMenu
    {
        private ICourseController _courseController;

        public CourseMenu (ICourseController courseController)
        {
            _courseController = courseController;
        }

        public void ShowMenu()
        {
            int option;

            do
            {
                Console.WriteLine("1. Registrar curso.");
                Console.WriteLine("2. Editar curso.");
                Console.WriteLine("3. Eliminar curso.");
                Console.WriteLine("4. Buscar curso.");
                Console.WriteLine("5. Mostrar cursos.");
                Console.WriteLine("6. Salir.");

                Console.Write("Seleccione una opcion: ");
                option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        _courseController.CreateCourse();
                        break;
                    case 2:
                        _courseController.UpdateCourse();
                        break;
                    case 3:
                        _courseController.DeleteCourse();
                        break;
                    case 4:
                        _courseController.GetCourseById();
                        break;
                    case 5:
                        _courseController.GetAllCourses();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (option != 6);
        }
    }
}
