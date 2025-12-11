using TE = SchoolAdministration.Domain.Teacher.Entities;
using SchoolAdministration.Application.Interfaces.Teacher;
using SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers;
using SchoolAdministration.Domain.Teacher.Interfaces;

namespace SchoolAdministration.Application.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly ITeacherValidator _teacherValidator;
        public TeacherService(ITeachersRepository teachersRepository, ITeacherValidator teacherValidator)
        {
            _teachersRepository = teachersRepository;
            _teacherValidator = teacherValidator;
        }

        public void CreateTeacher(TE.Teacher teacher)
        {
            _teacherValidator.ValidateTeacher(teacher);
            _teachersRepository.Add(teacher);
        }

        public TE.Teacher GetById(int id)
        {
            var teacher = _teachersRepository.GetById(id);

            if (teacher is null)
                throw new KeyNotFoundException($"No existe un profesor con Id {id}");

            return teacher;
        }

        public List<TE.Teacher> GetAll()
        {
            return _teachersRepository.GetAll().ToList();
        }

        public void UpdateTeacher(TE.Teacher teacher)
        {
            _teacherValidator.ValidateTeacher(teacher);
            _teachersRepository.Update(teacher);

        }


        public bool DeleteTeacher(int id)
        {
            return _teachersRepository.Delete(id);
        }

    }
}
