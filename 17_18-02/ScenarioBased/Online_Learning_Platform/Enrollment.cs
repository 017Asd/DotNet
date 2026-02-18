using System;

namespace Q5
{
    public class Enrollment
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment(Student student, Course course)
        {
            Student = student;
            Course = course;
            EnrollmentDate = DateTime.Now;
        }
    }
}
