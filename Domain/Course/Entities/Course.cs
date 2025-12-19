namespace SchoolAdministration.Domain.Course.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public int Max { get; set; }
        public int TeacherId { get; private set; }

        internal void SetId(int id)
        {
            Id = id; 
        }

        public Course (string rName, int rMax, int rTeacherId)
        {
            Name = rName;
            Max = rMax;
            TeacherId = rTeacherId;
        }

        public void Update (string uName, int uMax, int uTeacherId)
        {
            Name = uName;
            Max = uMax;
            TeacherId = uTeacherId;
        }
    }
}
