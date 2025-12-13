using SchoolAdministration.Domain.Course.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.ConsoleApp.Printers.CoursePrinter
{
    public class CoursesPrinter
    {
        public static void PrintCourse(Course c)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Id: {c.Id}");
            Console.WriteLine($"Nombre: {c.Name}");
            Console.WriteLine($"Cupo Maximo: {c.Max}");
            Console.WriteLine("----------------------------------");
        }
    }
}
