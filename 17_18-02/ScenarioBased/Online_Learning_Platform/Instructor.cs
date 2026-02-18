using System.Collections.Generic;

namespace Q5
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Instructor(int id, string name)
        {
            Id = id;
            Name = name;
            Courses = new List<Course>();
        }
    }
}
