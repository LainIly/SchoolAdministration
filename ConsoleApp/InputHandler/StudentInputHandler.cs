using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Person.Validators;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Validators.PersonValidator;

namespace SchoolAdministration.ConsoleApp.InputHandler
{
    public class StudentInputHandler
    {
        public static int GetId(IPersonValidator personValidator)
        {
            while (true)
            {
                Console.Write("Ingresa el Id a buscar: ");
                int id = int.Parse(Console.ReadLine()!);
                try
                {
                    personValidator.ValidateIdFormat(id);
                    return id;
                } catch (FormatException)
                {
                    Console.WriteLine("Id invalida. Id debe ser un numero entero.");
                    continue;
                }


            }
        } //Buscar. //Terminado
        public static Students GetData()
        {
            //Validar datos en la capa de presentacion.
            int id;
            while (true)
            {
                try
                {
                    Console.Write("Id: ");
                    id = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Id invalida. Id debe ser un numero entero.");
                    continue;
                }

                if (id < 0)
                {
                    Console.WriteLine("Id debe ser mayor a 0.");
                    continue;
                }
                break;
            }

            string? name;
            while (true)
            {
                Console.Write("Nombre: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    continue;
                }

                var nameWithoutSpaces = name.Replace(" ", "");

                if (!nameWithoutSpaces.All(char.IsLetter))
                {
                    Console.WriteLine("El nombre solo puede contener letras y espacios.");
                    continue;
                }
                    break;
            }

            string? email;
            while (true)
            {
                Console.Write("Correo: ");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("El correo no puede estar vacio.");
                    continue;
                }

                if (!EmailFormatValidator.ValidateEmail(email))
                {
                    Console.WriteLine("El correo no tiene un formato válido.");
                    continue;
                }

                break;
            }

            int age;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese Edad: ");
                    age = int.Parse(Console.ReadLine()!);
                } catch (FormatException)
                {
                    Console.WriteLine("Edad invalida. Edad debe ser un numero entero.");
                    continue;
                }

                if (age < 5 || age > 25)
                {
                    Console.WriteLine("La edad debe ser mayor a 5 y menor a 25 an/os.");
                    continue;
                }
                break;
            }

            string? program;
            while (true)
            {
                Console.Write("Ingrese Programa: ");
                program = Console.ReadLine()!;
                
                if (string.IsNullOrWhiteSpace(program))
                {
                    Console.WriteLine("El programa no puede estar vacio.");
                    continue;
                }

                var stringWithoutSpaces = program.Replace(" ", "");

                if (!stringWithoutSpaces.All(char.IsLetter))
                {
                    Console.WriteLine("Programa solo debe tener letras.");
                    continue;
                }
                break;
            }

            decimal average;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese Promedio: ");
                    average = decimal.Parse(Console.ReadLine()!);
                } catch (FormatException)
                {
                    Console.WriteLine("Promedio invalido. Promedio debe ser un decimal entero.");
                    continue;
                }

                if (average < 0 || average > 5)
                {
                    Console.WriteLine("El rango del promedio debe ser entre 0.0 y 5.0.");
                    continue;
                }
                break;
            }
            
            //Creamos el objeto (Todo lo valida el service)
            var student = new Students(id, name, email, age, program, average);

            return student;
        } //Crear. //Terminado. Validaciones solo para la capa UI.
        public static Students GetUpdatedStudentData()
        {
            Console.Write("Ingrese Nombre: ");
            string name = Console.ReadLine()!;

            Console.Write("Ingrese Correo: ");
            string email = Console.ReadLine()!;

            Console.Write("Ingrese Edad: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Ingrese Programa: ");
            string program = Console.ReadLine()!;

            Console.Write("Ingrese Promedio: ");
            decimal average = decimal.Parse(Console.ReadLine()!);

            return new Students(0, name, email, age, program, average);
        }
    }
}
