using SchoolAdministration.Domain.Infrastructure.Interfaces.Students;
using SE = SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        //Lista, [] es lo mismo que = new List<Student>();
        private readonly List<SE.Students> _students = [];
        public IReadOnlyList<SE.Students> Students => _students.AsReadOnly(); //Copia de lista, solo lectura.

        //Metodos de Manejo de Datos (CRUD)
        public void Add(SE.Students student)
        {
            int newId = _students.Count == 0 ? 1 : _students.Max(s => s.Id) + 1;

            student.SetId(newId);

            _students.Add(student);
        }

        public SE.Students GetById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                throw new KeyNotFoundException();
            return student;
        }

        public IReadOnlyList<SE.Students> GetAll() => _students.AsReadOnly();

        public void Update(SE.Students updated)
        {
            var existing = GetById(updated.Id);

            if (existing == null)
                throw new KeyNotFoundException($"No existe un estudiante con Id {updated.Id}.");

            existing.Update(
                updated.Name,
                updated.Email,
                updated.Age,
                updated.Program,
                updated.Average
            );
        }

        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id); //Trae el estudiante solicitado.

            if (student is null) //Si no existe, quibra.
                return false;

            return _students.Remove(student); //Si pasa, retorna y elimina.
        }
    }
}
