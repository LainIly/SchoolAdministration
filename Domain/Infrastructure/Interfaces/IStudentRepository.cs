using SchoolAdministration.Domain.Student.Entities;
namespace SchoolAdministration.Domain.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Students student);
        Students? GetById(int id);
        IReadOnlyList<Students> GetAll();
        void Update (Students student);
        bool Delete(int id);
    }
}
