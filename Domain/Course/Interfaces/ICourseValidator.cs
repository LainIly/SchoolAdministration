using System.Runtime.InteropServices;
using CE = SchoolAdministration.Domain.Course.Entities;

namespace SchoolAdministration.Domain.Course.Interfaces
{
    public interface ICourseValidator
    {
        void ValidateCouseIdFormat(int id);
        void ValidateNameFormat(string name);
        void ValidateMaxFormat(int max);
        void ValidateTeacherIdFormat(int teacherId);

        public void ValidateCourse(CE.Course course);
    }
}
