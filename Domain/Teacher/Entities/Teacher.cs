using SchoolAdministration.Domain.Person.Entities;

namespace SchoolAdministration.Domain.Teacher.Entities
{
    public class Teacher : People
    {
        public string Degree { get; set; } = "";
        public int YearsE { get; set; }


        public Teacher (string cName, string cEmail, int cAge, string cDegree, int cYearsE)
        {
            Name = cName;
            Email = cEmail;
            Age = cAge;
            Degree = cDegree;
            YearsE = cYearsE;
        }

        public void Update (string name, string email, int age, string degree, int yearsE)
        {
            Name = name;
            Email = email;
            Age = age;
            Degree = degree;
            YearsE = yearsE;
        }
    }
}
