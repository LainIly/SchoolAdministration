using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Domain.Teacher.Interfaces
{
    public interface ITeacherController
    {
        void CreateTeacher();
        void UpdateTeacher();
        void DeleteTeacher();
        void GetTeacherById();
        void GetAllTeachers();
    }
}
