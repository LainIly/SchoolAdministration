using SchoolAdministration.Domain.Infrastructure.Interfaces;
using SchoolAdministration.Domain.Student.Entities;

namespace SchoolAdministration.Domain.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        //Lista, [] es lo mismo que = new List<Student>();
        private readonly List<Students> _students = [];
        public IReadOnlyList<Students> Students => _students.AsReadOnly(); //Copia de lista, solo lectura.

        //Metodos de Manejo de Datos (CRUD)
        public void Add (Students student) => _students.Add(student);
        public Students? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public IReadOnlyList<Students> GetAll() => _students.AsReadOnly();

        public void Update(Students student)
        {
            var index = _students.FindIndex(s => s.Id == student.Id); //Recibos el estudiante

            if (index == -1) //Si no lo encontramos.
                throw new KeyNotFoundException($"No existe un estudiante con Id {student.Id}.");

            _students[index] = student; //Actualizamos.
        }

        public bool Delete (int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id); //Trae el estudiante solicitado.

            if (student is null) //Si no existe, quibra.
                return false;

            return _students.Remove(student); //Si pasa, retorna y elimina.
        }
    }
}
