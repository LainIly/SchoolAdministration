using SE = SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Interfaces.Students
{
    public interface IStudentRepository
    {
        void Add(SE.Students student);
        SE.Students? GetById(int id);
        IReadOnlyList<SE.Students> GetAll();
        void Update(SE.Students student);
        bool Delete(int id);
    }
}
