using System;
using System.Collections.Generic;
using System.Linq;

// Base constraints
public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}


public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();
    
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (student == null || course == null)
            throw new ArgumentNullException();

        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        var students = _enrollments[course];

        
        if (students.Count >= course.MaxCapacity)
        {
            Console.WriteLine("Enrollment failed: Course at full capacity.");
            return false;
        }

        
        if (students.Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine("Enrollment failed: Student already enrolled.");
            return false;
        }

      
        var prop = course.GetType().GetProperty("RequiredSemester");
        if (prop != null)
        {
            int requiredSemester = (int)prop.GetValue(course);
            if (student.Semester < requiredSemester)
            {
                Console.WriteLine("Enrollment failed: Prerequisite not met.");
                return false;
            }
        }

        students.Add(student);
        Console.WriteLine("Enrollment successful.");
        return true;
    }
    
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.ContainsKey(course))
            return _enrollments[course].AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }
    
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }
    
    public int CalculateStudentWorkload(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Sum(e => e.Key.Credits);
    }
}


public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}


public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100.");

        if (!_enrollmentSystem.GetStudentCourses(student).Contains(course))
            throw new InvalidOperationException("Student not enrolled in course.");

        _grades[(student, course)] = grade;
    }
    
    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(g => g.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalWeighted = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            totalWeighted += entry.Value * entry.Key.Item2.Credits;
            totalCredits += entry.Key.Item2.Credits;
        }

        return totalWeighted / totalCredits;
    }
    
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(g => g.Key.Item2.Equals(course));

        if (!courseGrades.Any())
            return null;

        var top = courseGrades
            .OrderByDescending(g => g.Value)
            .First();

        return (top.Key.Item1, top.Value);
    }
}
