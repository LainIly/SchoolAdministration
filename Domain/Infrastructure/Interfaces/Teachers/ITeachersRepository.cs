using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers
{
    public interface ITeachersRepository
    {
        void Add (TE.Teacher teacher);
        TE.Teacher GetById (int id);
        IReadOnlyList<TE.Teacher> GetAll();
        void Update (TE.Teacher teacher);
        bool Delete(int id);
    }
}
