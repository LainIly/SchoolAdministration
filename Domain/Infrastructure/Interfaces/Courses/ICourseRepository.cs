using CE = SchoolAdministration.Domain.Course.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Interfaces.Courses
{   
    public interface ICourseRepository
    {
        void Add(CE.Course course);
        CE.Course? GetById(int id);
        IReadOnlyList<CE.Course> GetAll();
        void Update(CE.Course course);
        bool Delete(int id);
    }
}
