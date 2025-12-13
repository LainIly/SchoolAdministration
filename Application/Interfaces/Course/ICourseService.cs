using CE = SchoolAdministration.Domain.Course.Entities;

namespace SchoolAdministration.Application.Interfaces.Course
{
    public interface ICourseService
    {
        void CreateCourse(CE.Course course);
        CE.Course GetById(int id);
        List<CE.Course> GetAll();
        void UpdateCourse(CE.Course course);
        bool DeleteCourse(int id);
    }
}
