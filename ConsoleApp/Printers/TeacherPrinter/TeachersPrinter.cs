using SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.ConsoleApp.Printers.TeacherPrinter
{
    public class TeachersPrinter
    {
        public static void PrintTeacher(Teacher t)
        {
            Console.WriteLine($"Id: {t.Id}");
            Console.WriteLine($"Nombre: {t.Name}");
            Console.WriteLine($"Correo: {t.Email}");
            Console.WriteLine($"Edad: {t.Age}");
            Console.WriteLine($"Programa: {t.Degree}");
            Console.WriteLine($"Promedio: {t.YearsE}");
            Console.WriteLine("----------------------------------");
        }
    }
}
