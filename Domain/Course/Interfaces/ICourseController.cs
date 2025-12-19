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
