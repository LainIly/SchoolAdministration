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
