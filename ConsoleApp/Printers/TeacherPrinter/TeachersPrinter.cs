using SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.ConsoleApp.Printers.TeacherPrinter
{
    public class TeachersPrinter
    {
        public static void PrintTeacher(Teacher t)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Id: {t.Id}");
            Console.WriteLine($"Nombre: {t.Name}");
            Console.WriteLine($"Correo: {t.Email}");
            Console.WriteLine($"Edad: {t.Age}");
            Console.WriteLine($"Especialidad: {t.Degree}");
            Console.WriteLine($"An/os de experiencia: {t.YearsE}");
            Console.WriteLine("----------------------------------");
        }
    }
}
