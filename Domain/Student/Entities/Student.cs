using SchoolAdministration.Domain.Person.Entities;

namespace SchoolAdministration.Domain.Student.Entities
{
    public class Students : People
    {
        public string Program { get; set; } = "";
        public decimal Average { get; set; }

        public Students(string cName, string cEmail, int cAge, string cProgram, decimal cAverage)
        {
            Name = cName;
            Email = cEmail;
            Age = cAge;
            Program = cProgram;
            Average = cAverage;
        }

        public void Update(string name, string email, int age, string program, decimal average)
        {
            Name = name;
            Email = email;
            Age = age;
            Program = program;
            Average = average;
        }
    }
}
