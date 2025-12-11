using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.ConsoleApp.Menu.StudentsMenu
{
    public class StudentMenu
    {
        private IStudentController _studentController;

        public StudentMenu (IStudentController studentController)
        {
            _studentController = studentController;
        }

        public void ShowMenu ()
        {
            int option;

            do
            {
                Console.WriteLine("1. Registrar estudiante.");
                Console.WriteLine("2. Editar estudiante.");
                Console.WriteLine("3. Eliminar estudiante.");
                Console.WriteLine("4. Buscar estudiante.");
                Console.WriteLine("5. Mostrar estudiantes.");
                Console.WriteLine("6. Salir.");

                Console.Write("Seleccione una opcion: ");
                option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        _studentController.CreateStudent();
                        break;
                    case 2:
                        _studentController.UpdateStudent();
                        break;
                    case 3:
                        _studentController.DeleteStudent();
                        break;
                    case 4:
                        _studentController.GetStudentById();
                        break;
                    case 5:
                        _studentController.GetAllStudents();
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
