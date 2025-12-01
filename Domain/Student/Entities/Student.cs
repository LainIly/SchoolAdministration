using SchoolAdministration.Domain.Person.Entities;

namespace SchoolAdministration.Domain.Student.Entities
{
    public class Students : People
    {
        public string Program { get; set; } = "";
        public decimal Average { get; set; }

        public Students (int cId, string cName, string cEmail, int cAge, string cProgram, decimal cAverage)
        {
            Id = cId;
            Name = cName;
            Email = cEmail;
            Age = cAge;
            Program = cProgram;
            Average = cAverage;
        }
    }
}
