using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Domain.Course.Interfaces
{
    public interface ICourseController
    {
        void CreateCourse();
        void UpdateCourse();
        void DeleteCourse();
        void GetCourseById();
        void GetAllCourses();
    }
}
