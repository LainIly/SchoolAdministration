using SchoolAdministration.Domain.Teacher.Interfaces;

namespace SchoolAdministration.ConsoleApp.Menu.TeachersMenu
{
    public class TeacherMenu
    {
        private ITeacherController _teacherController;

        public TeacherMenu (ITeacherController teacherController)
        {
            _teacherController = teacherController;
        }

        public void ShowMenu()
        {
            int option;

            do
            {
                Console.WriteLine("1. Registrar profesor.");
                Console.WriteLine("2. Editar profesor.");
                Console.WriteLine("3. Eliminar profesor.");
                Console.WriteLine("4. Buscar profesor.");
                Console.WriteLine("5. Mostrar profesores.");
                Console.WriteLine("6. Salir.");

                Console.Write("Seleccione una opcion: ");
                option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        _teacherController.CreateTeacher();
                        break;
                    case 2:
                        _teacherController.UpdateTeacher();
                        break;
                    case 3:
                        _teacherController.DeleteTeacher();
                        break;
                    case 4:
                        _teacherController.GetTeacherById();
                        break;
                    case 5:
                        _teacherController.GetAllTeachers();
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
