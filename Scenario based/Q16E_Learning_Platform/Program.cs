using System;
namespace Scenario{

class Program
{
    static void Main()
    {
        var manager = new LearningManager();

        manager.AddCourse(
            "CS101",
            "Introduction to C#",
            "Alice Johnson",
            8,
            199.99,
            new List<string> { "Basics", "OOP", "Collections", "LINQ" }
        );

        manager.AddCourse(
            "WEB201",
            "ASP.NET Core",
            "Bob Smith",
            10,
            299.99,
            new List<string> { "MVC", "Web API", "Entity Framework", "Authentication" }
        );

        manager.EnrollStudent("STU001", "CS101");
        manager.EnrollStudent("STU002", "CS101");
        manager.EnrollStudent("STU003", "WEB201");

        manager.UpdateProgress("STU001", "CS101", "Basics", 85);
        manager.UpdateProgress("STU001", "CS101", "OOP", 90);

        manager.UpdateProgress("STU002", "CS101", "Basics", 70);
        manager.UpdateProgress("STU002", "CS101", "OOP", 75);

        manager.UpdateProgress("STU003", "WEB201", "MVC", 88);
        manager.UpdateProgress("STU003", "WEB201", "Web API", 92);

        var groupedCourses = manager.GroupCoursesByInstructor();

        foreach (var instructor in groupedCourses)
        {
            Console.WriteLine(instructor.Key);
            foreach (var course in instructor.Value)
            {
                Console.WriteLine($"{course.CourseCode} - {course.CourseName}");
            }
        }

        var topStudents = manager.GetTopPerformingStudents("CS101", 2);

        foreach (var enrollment in topStudents)
        {
            Console.WriteLine($"{enrollment.StudentId} {enrollment.ProgressPercentage:F2}%");
        }

        Console.ReadKey();
    }
}
}