using System;
using System.Collections.Generic;

namespace Q5
{
    public class Program
    {
        public static void Main()
        {
            // Collections
            List<Course> courses = new List<Course>();
            List<Student> students = new List<Student>();
            List<Instructor> instructors = new List<Instructor>();
            List<Enrollment> enrollments = new List<Enrollment>();

            // Create Instructor
            Instructor instructor1 = new Instructor(1, "Dr. Brown");
            instructors.Add(instructor1);

            // Create Course
            Course course1 = new Course("C101", "C# Programming", 2);
            courses.Add(course1);

            // Assign course to instructor
            instructor1.Courses.Add(course1);

            // Create Students
            Student s1 = new Student(101, "Rahul");
            Student s2 = new Student(102, "Aman");
            Student s3 = new Student(103, "Priya");

            students.Add(s1);
            students.Add(s2);
            students.Add(s3);

            Console.WriteLine("=== Enrollment Process ===");

            try
            {
                course1.EnrollStudent(s1);
                course1.EnrollStudent(s2);

                // This should fail (capacity = 2)
                course1.EnrollStudent(s3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nTrying duplicate enrollment...");

            try
            {
                // This should fail (duplicate)
                course1.EnrollStudent(s1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n=== Assignment Section ===");

            Assignment assignment1 = new Assignment(
                1,
                "OOP Concepts",
                DateTime.Now.AddDays(1),
                course1,
                instructor1
            );

            course1.Assignments.Add(assignment1);

            try
            {
                // Valid submission
                assignment1.Submit(DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nSubmitting after deadline...");

            try
            {
                // Late submission (should fail)
                assignment1.Submit(DateTime.Now.AddDays(2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\n=== Final Enrollment List ===");

            foreach (var enrollment in course1.Enrollments)
            {
                Console.WriteLine($"{enrollment.Student.Name} enrolled in {course1.CourseName}");
            }
        }
    }
}
