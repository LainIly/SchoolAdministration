namespace SchoolAdministration.Domain.Person.Entities
{
    public abstract class People
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
    }
}
