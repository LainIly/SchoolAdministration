using SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.ConsoleApp.Printers.StudentPrinter
{
    public class StudentsPrinter
    {
        public static void PrintStudent(Students s)
        {
            Console.WriteLine($"Id: {s.Id}");
            Console.WriteLine($"Nombre: {s.Name}");
            Console.WriteLine($"Correo: {s.Email}");
            Console.WriteLine($"Edad: {s.Age}");
            Console.WriteLine($"Programa: {s.Program}");
            Console.WriteLine($"Promedio: {s.Average}");
            Console.WriteLine("----------------------------------");
        }
    }
}
