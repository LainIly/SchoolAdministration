using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Domain.Course.Interfaces;
using SchoolAdministration.Domain.Person.Interfaces;
using SchoolAdministration.Domain.Student.Interfaces;
using SchoolAdministration.Domain.Teacher.Interfaces;

namespace SchoolAdministration.ConsoleApp.InputHandler.Helper
{
    public class ConsoleValidationHelper
    {
        private readonly INotificationService _notificationService;

        public ConsoleValidationHelper(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        //Validaciones Consola Estudiantes
        public int ValidateId(IPersonValidator personValidator)
        {
            while (true)
            {
                Console.Write("Ingrese el Id: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int id))
                {
                    _notificationService.Error($"Id invalida: {input}");
                    continue;
                }

                try
                {
                    personValidator.ValidateIdFormat(id); //Llama al validator del dominio (Reutilizar codigo.)
                    return id;
                }
                catch (ArgumentOutOfRangeException ex) //Captura el error del validator.
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public string ValidateName(IPersonValidator personValidator)
        {
            while (true)
            {
                Console.Write("Nombre: ");
                string? name = Console.ReadLine()!;

                try
                {
                    personValidator.ValidateNameFormat(name);
                    return name;
                }
                catch (ArgumentException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }//Bien
        public string ValidateEmail(IPersonValidator personValidator)
        {
            while (true)
            {
                Console.Write("Correo: ");
                string? email = Console.ReadLine()!;

                try
                {
                    personValidator.ValidateEmailFormat(email);
                    return email;
                }
                catch (FormatException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public int ValidateAge(IPersonValidator personValidator)
        {
            while (true)
            {
                Console.Write("Edad: ");
                try
                {
                    int age = int.Parse(Console.ReadLine()!);
                    personValidator.ValidateAgeFormat(age);
                    return age;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public string ValidateProgram(IStudentValidator studentValidator)
        {
            while (true)
            {
                Console.Write("Programa: ");
                string? program = Console.ReadLine()!;

                try
                {
                    studentValidator.ValidateProgramFormat(program);
                    return program;
                }
                catch (ArgumentException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public decimal ValidateAverage(IStudentValidator studentValidator)
        {
            while (true)
            {
                Console.Write("Promedio: ");

                try
                {
                    decimal average = decimal.Parse(Console.ReadLine()!);
                    studentValidator.ValidateAverageFormat(average);
                    return average;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }

        //Validaciones Consola Profesores
        public string ValidateDegree (ITeacherValidator teacherValidator)
        {
            while (true)
            {
                Console.Write("Titulo: ");
                string? degree = Console.ReadLine()!;

                try
                {
                    teacherValidator.ValidateDegreeFormat(degree);
                    return degree;
                } catch (ArgumentException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public int ValidateYearsE (ITeacherValidator teacherValidator)
        {
            while (true)
            {
                Console.Write("An/os de experiencia: ");
                
                try
                {
                    int yearsE = int.Parse(Console.ReadLine()!);
                    teacherValidator.ValidateYearsEFormat(yearsE);
                    return yearsE;
                } catch (ArgumentOutOfRangeException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public int ValidateTeacherAge(ITeacherValidator teacherValidator)
        {
            while (true)
            {
                Console.Write("Edad: ");
                try
                {
                    int age = int.Parse(Console.ReadLine()!);
                    teacherValidator.ValidateTeacherAge(age);
                    return age;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }

        //Validaciones Consola Cursos
        public int ValidateCourseId(ICourseValidator courseValidator)
        {
            while (true)
            {
                Console.Write("Id: ");
                try
                {
                    int id = int.Parse(Console.ReadLine()!);
                    courseValidator.ValidateCouseIdFormat(id);
                    return id;
                } catch (ArgumentException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public string ValidateCourseName(ICourseValidator courseValidator)
        {
            while (true)
            {
                Console.Write("Nombre del curso: ");

                try
                {
                    string? name = Console.ReadLine()!;
                    courseValidator.ValidateNameFormat(name);
                    return name;
                } catch (ArgumentException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
        public int ValidaMaxCourse(ICourseValidator courseValidator)
        {
            while (true)
            {
                Console.Write("Cupo: ");

                try
                {
                    int max = int.Parse(Console.ReadLine()!);
                    courseValidator.ValidateMaxFormat(max);
                    return max;
                } catch (ArgumentOutOfRangeException ex)
                {
                    _notificationService.Error(ex.Message);
                    continue;
                }
            }
        }
    }
}
