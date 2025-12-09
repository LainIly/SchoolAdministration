using SchoolAdministration.Domain.Infrastructure.Interfaces.Teachers;
using TE = SchoolAdministration.Domain.Teacher.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Repositories.Teachers
{
    public class TeacherRepository : ITeachersRepository
    {
        private readonly List<TE.Teacher> _teacher = [];
        public IReadOnlyList<TE.Teacher> teachers => _teacher.AsReadOnly();

        //Metodos del repositorio.

        public void Add (TE.Teacher teacher)
        {
            int newId = _teacher.Count == 0 ? 1 : _teacher.Max(t => t.Id) + 1;
            teacher.SetId(newId);

            _teacher.Add(teacher);  
        }

        public TE.Teacher GetById(int id)
        {
            var teacher = _teacher.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                throw new KeyNotFoundException();
            return teacher;
        }

        public IReadOnlyList<TE.Teacher> GetAll() => _teacher.AsReadOnly();

        public void Update(TE.Teacher teacher)
        {
            var existing = GetById(teacher.Id);
            if (existing == null)
                throw new KeyNotFoundException($"No existe un profesor con Id {teacher.Id}");

            existing.Update(
                teacher.Name,
                teacher.Email,
                teacher.Age,
                teacher.Degree,
                teacher.YearsE
            );
        }

        public bool Delete (int id)
        {
            var teacher = _teacher.FirstOrDefault(t => t.Id == id);

            if (teacher is null)
                throw new KeyNotFoundException();

            return _teacher.Remove(teacher);
        }
    }
}
