using SchoolAdministration.Domain.Course.Entities;
using SchoolAdministration.Domain.Teacher.Entities;
using SE = SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.ConsoleApp.Printers.CoursePrinter
{
    public class CoursesPrinter
    {
        public static void PrintCourse(Course c, Teacher t, SE.Students s)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Id: {c.Id}");
            Console.WriteLine($"Nombre: {c.Name}");
            Console.WriteLine($"Cupo Maximo: {c.Max}");
            Console.WriteLine($"Id Profesor: {t.Id}");
            Console.WriteLine($"Profesor asignado: {t.Name}");
            Console.WriteLine($"Id Estudiante: {s.Id}");
            Console.WriteLine($"Estudiante asignado: {s.Name}");
            Console.WriteLine("----------------------------------");
        }
    }
}