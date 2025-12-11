using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.Domain.Teacher.Interfaces
{
    public interface ITeacherValidator
    {
        public void ValidateDegreeFormat(string degree);
        public void ValidateYearsEFormat(int yearsE);
        public void ValidateTeacherAge(int age);

        //Validar profesor
        public void ValidateTeacher(TE.Teacher teacher);
    }
}
