namespace SchoolAdministration.Domain.Person.Entities
{
    public abstract class People
    {
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }

        internal void SetId (int id)
        {
            Id = id;
        }
    }
}
