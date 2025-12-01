using SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.Application.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(Students student);
        Students GetById(int id);
        List<Students> GetAll();
        void UpdateStudent(Students student);
        bool DeleteStudent(int id);
    }
}
