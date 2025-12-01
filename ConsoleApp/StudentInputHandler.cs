using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.ConsoleApp
{
    public static class StudentInputHandler
    {
        public static Students GetData()
        {
            Console.Write("Ingrese Id: ");
            int id = int.Parse(Console.ReadLine()!);

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

            //Creamos el objeto (Todo lo valida el service)
            var student = new Students(id, name, email, age, program, average);

            return student;
        } //Crear.

        public static int GetId()
        {
            while (true)
            {
                Console.Write("Ingresa el Id a buscar: ");
                int id = int.Parse(Console.ReadLine()!);

                if (id < 0)
                {
                    Console.WriteLine("Id debe ser mayor a 0.");
                    continue;
                }
                return id;
            }
        } //Buscar.

        public static int GetIdForUpdate()
        {
            while (true)
            {
                Console.Write("Ingrese el Id del estudiante a editar: ");
                int id = int.Parse(Console.ReadLine()!);

                if (id < 0)
                {
                    Console.WriteLine("Id debe ser mayor a 0.");
                    continue;
                }
                return id;
            }
        } //Buscar para actualizar.

        public static int GetIdForDelete()
        {
            while (true)
            {
                Console.Write("Ingrese el Id del estudiante a eliminar: ");
                int id = int.Parse(Console.ReadLine()!);

                if (id < 0)
                {
                    Console.WriteLine("Id debe ser mayor a 0.");
                    continue;
                }
                return id;
            }
        }

        public static Students GetUpdatedStudentData()
        {
            Console.Write("Ingrese Id: ");
            int id = int.Parse(Console.ReadLine()!);

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

            return new Students(id, name, email, age, program, average);
        }
    }
}
