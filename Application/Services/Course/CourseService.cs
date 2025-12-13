using SchoolAdministration.Application.Interfaces.Course;
using SchoolAdministration.Domain.Course.Interfaces;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Courses;
using CE = SchoolAdministration.Domain.Course.Entities;

namespace SchoolAdministration.Application.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseValidator _courseValidator;

        public CourseService (ICourseRepository courseRepository, ICourseValidator courseValidator)
        {
            _courseRepository = courseRepository;
            _courseValidator = courseValidator;
        }

        public void CreateCourse(CE.Course course)
        {
            _courseValidator.ValidateCourse(course);
            _courseRepository.Add(course);
        }

        public CE.Course GetById(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course is null)
                throw new KeyNotFoundException($"No existe un curso con Id {id}");

            return course;
        }

        public List<CE.Course> GetAll()
        {
            return _courseRepository.GetAll().ToList();
        }

        public void UpdateCourse (CE.Course course)
        {
            _courseValidator.ValidateCourse(course);
            _courseRepository.Update(course);
        }

        public bool DeleteCourse(int id)
        {
            return _courseRepository.Delete(id);
        }
    }
}
