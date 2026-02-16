using System;

class Program
{
    static void Main()
    {
        var student1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3, Specialization = "CSE" };
        var student2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 2, Specialization = "ECE" };
        var student3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 4, Specialization = "ME" };

        var course1 = new LabCourse
        {
            CourseCode = "CS301",
            Title = "Advanced Programming Lab",
            MaxCapacity = 2,
            Credits = 4,
            RequiredSemester = 3
        };

        var course2 = new LabCourse
        {
            CourseCode = "CS401",
            Title = "AI Lab",
            MaxCapacity = 1,
            Credits = 5,
            RequiredSemester = 4
        };

        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        // Successful enrollment
        enrollment.EnrollStudent(student1, course1);
        enrollment.EnrollStudent(student3, course1);

        // Failed (capacity)
        enrollment.EnrollStudent(student2, course1);

        // Failed (prerequisite)
        enrollment.EnrollStudent(student2, course2);

        // Successful
        enrollment.EnrollStudent(student3, course2);

        var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        gradebook.AddGrade(student1, course1, 85);
        gradebook.AddGrade(student3, course1, 92);
        gradebook.AddGrade(student3, course2, 88);

        Console.WriteLine("\nGPA of Charlie:");
        Console.WriteLine(gradebook.CalculateGPA(student3));

        Console.WriteLine("\nTop Student in CS301:");
        var top = gradebook.GetTopStudent(course1);
        if (top.HasValue)
            Console.WriteLine($"{top.Value.student.Name} - {top.Value.grade}");

        Console.ReadKey();
    }
}
