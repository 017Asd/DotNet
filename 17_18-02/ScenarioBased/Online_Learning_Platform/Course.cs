using System.Collections.Generic;

namespace Q5
{
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public int MaxCapacity { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course(string id, string name, int maxCapacity)
        {
            CourseID = id;
            CourseName = name;
            MaxCapacity = maxCapacity;
            Enrollments = new List<Enrollment>();
            Assignments = new List<Assignment>();
        }

        public void EnrollStudent(Student student)
        {
            if (Enrollments.Count >= MaxCapacity)
                throw new CourseCapacityExceededException("Course capacity reached.");

            foreach (var enrollment in Enrollments)
            {
                if (enrollment.Student.Id == student.Id)
                    throw new DuplicateEnrollmentException("Student already enrolled in this course.");
            }

            Enrollment newEnrollment = new Enrollment(student, this);
            Enrollments.Add(newEnrollment);
        }
    }
}
