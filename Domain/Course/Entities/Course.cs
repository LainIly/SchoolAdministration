namespace SchoolAdministration.Domain.Course.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public int Max { get; set; }

        internal void SetId(int id)
        {
            Id = id; 
        }

        public Course (string rName, int rMax)
        {
            Name = rName;
            Max = rMax;
        }

        public void Update (string uName, int uMax)
        {
            Name = uName;
            Max = uMax;
        }
    }
}
