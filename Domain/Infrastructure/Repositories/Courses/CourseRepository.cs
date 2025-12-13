using CE = SchoolAdministration.Domain.Course.Entities;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Courses;

namespace SchoolAdministration.Domain.Infrastructure.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<CE.Course> _courses = [];
        public IReadOnlyList<CE.Course> Courses => _courses.AsReadOnly();

        public void Add(CE.Course course)
        {
            int newId = _courses.Count == 0 ? 1 : _courses.Max(c => c.Id) + 1;

            course.SetId(newId);
            _courses.Add(course);
        }

        public CE.Course GetById(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course is null)
                throw new KeyNotFoundException();
            return course;
        }

        public IReadOnlyList<CE.Course> GetAll() => _courses.AsReadOnly();

        public void Update(CE.Course course)
        {
            var existing = GetById(course.Id);
            if (existing is null)
                throw new KeyNotFoundException($"No existe un curso con Id {course.Id}");

            existing.Update (
                course.Name,
                course.Max
            );
        }

        public bool Delete(int id)
        {
            var courses = _courses.FirstOrDefault(c => c.Id == id);

            if (courses is null)
                return false;

            return _courses.Remove(courses);
        }
    }
}
