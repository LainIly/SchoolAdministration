using CE = SchoolAdministration.Domain.Course.Entities;
using SchoolAdministration.Domain.Course.Interfaces;

namespace SchoolAdministration.Domain.Course.Validators
{
    public class CourseValidator : ICourseValidator
    {
        public void ValidateCouseIdFormat(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Id debe ser mayor a 0.", nameof(id));
        }

        public void ValidateNameFormat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El programa no puede estar vacio.", nameof(name));
        }

        public void ValidateMaxFormat(int max)
        {
            if (max < 0 || max > 35) 
                throw new ArgumentOutOfRangeException("El cupo debe ser mayor a 0 y menor a 35.", nameof(max));
        }

        public void ValidateCourse(CE.Course course)
        {
            if (course is null)
                throw new ArgumentNullException(nameof(course));

            ValidateNameFormat(course.Name);
            ValidateMaxFormat(course.Max);
        }
    }
}
