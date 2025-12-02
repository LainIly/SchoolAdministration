using SchoolAdministration.Domain.Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Domain.Student.Interfaces
{
    public interface IStudentController
    {
        void CreateStudent();
        void UpdateStudent();
        void DeleteStudent();
        void GetStudentById();
        void GetAllStudents();
    }
}
