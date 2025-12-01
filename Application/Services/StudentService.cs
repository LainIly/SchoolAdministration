using SchoolAdministration.Application.Interfaces;
using SchoolAdministration.Domain.Infrastructure.Interfaces;
using SchoolAdministration.Domain.Infrastructure.Repositories;
using SchoolAdministration.Domain.Student.Entities;
using SchoolAdministration.Domain.Student.Interfaces;

namespace SchoolAdministration.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentValidator _studentValidator;

        public StudentService(IStudentRepository studentRepository, IStudentValidator studentValidator)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
        }

        public void CreateStudent(Students student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            //validar reglas antes de crear el estudiante.
            _studentValidator.ValidateStudent(student);

            //Repositorio
            _studentRepository.Add(student);
        }
        public void UpdateStudent (Students student)
        {
            _studentValidator.ValidateStudent(student);
            _studentRepository.Update(student);
        }

        public Students GetById(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student is null)
                throw new KeyNotFoundException($"No existe un estudiane con Id {id}");

            return student;
        }

        public List<Students> GetAll ()
        {
            return _studentRepository.GetAll().ToList();
        }

        public bool DeleteStudent (int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}
