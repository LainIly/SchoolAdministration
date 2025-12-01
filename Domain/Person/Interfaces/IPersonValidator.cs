using SchoolAdministration.Domain.Person.Entities;

namespace SchoolAdministration.Domain.Person.Interfaces
{
    public interface IPersonValidator
    {
        //Metodos
        public void ValidateIdFormat(int id);
        public void ValidateNameFormat(string name);
        public void ValidateEmailFormat(string email);
        public void ValidateAgeFormat(int age);

        //Validar Persona

        public void ValidatePerson(People people);
    }
}
