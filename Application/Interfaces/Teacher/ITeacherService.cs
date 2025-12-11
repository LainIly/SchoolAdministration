using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.Application.Interfaces.Teacher
{
    public interface ITeacherService
    {
        void CreateTeacher(TE.Teacher teacher);
        TE.Teacher GetById(int id);
        List<TE.Teacher> GetAll();
        void UpdateTeacher(TE.Teacher teacher);
        bool DeleteTeacher(int id);
    }
}
