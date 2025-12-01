using SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.Domain.Student.Interfaces
{
    public interface IStudentValidator
    {
        public void ValidateProgramFormat(string program);
        public void ValidateAverageFormat(decimal average);

        //Validar estudiante
        public void ValidateStudent(Students student);
    }
}
