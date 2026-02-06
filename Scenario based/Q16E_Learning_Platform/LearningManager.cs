using System;

namespace Scenario{
public class LearningManager
{
    private readonly List<Course> _courses = new();
    private readonly List<Enrollment> _enrollments = new();
    private readonly List<StudentProgress> _progressRecords = new();

    private int _nextEnrollmentId = 1;

    // Add a new course
    public void AddCourse(string code, string name, string instructor,
                          int weeks, double price, List<string> modules)
    {
        if (_courses.Any(c => c.CourseCode == code))
            throw new InvalidOperationException("Course already exists.");

        _courses.Add(new Course
        {
            CourseCode = code,
            CourseName = name,
            Instructor = instructor,
            DurationWeeks = weeks,
            Price = price,
            Modules = modules
        });
    }

    // Enroll a student into a course
    public bool EnrollStudent(string studentId, string courseCode)
    {
        if (!_courses.Any(c => c.CourseCode == courseCode))
            return false;

        if (_enrollments.Any(e => e.StudentId == studentId &&
                                  e.CourseCode == courseCode))
            return false;

        _enrollments.Add(new Enrollment
        {
            EnrollmentId = _nextEnrollmentId++,
            StudentId = studentId,
            CourseCode = courseCode,
            EnrollmentDate = DateTime.UtcNow,
            ProgressPercentage = 0
        });

        _progressRecords.Add(new StudentProgress
        {
            StudentId = studentId,
            CourseCode = courseCode,
            LastAccessed = DateTime.UtcNow
        });

        return true;
    }

    // Update module score and progress
    public bool UpdateProgress(string studentId, string courseCode,
                               string module, double score)
    {
        var course = _courses.FirstOrDefault(c => c.CourseCode == courseCode);
        if (course == null || !course.Modules.Contains(module))
            return false;

        var progress = _progressRecords.FirstOrDefault(p =>
            p.StudentId == studentId && p.CourseCode == courseCode);

        if (progress == null)
            return false;

        progress.ModuleScores[module] = score;
        progress.LastAccessed = DateTime.UtcNow;

        var enrollment = _enrollments.First(e =>
            e.StudentId == studentId && e.CourseCode == courseCode);

        enrollment.ProgressPercentage =
            (double)progress.ModuleScores.Count / course.Modules.Count * 100;

        return true;
    }

    // Group courses by instructor
    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        return _courses
            .GroupBy(c => c.Instructor)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get top performing students by average module score
    public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
    {
        return _progressRecords
            .Where(p => p.CourseCode == courseCode && p.ModuleScores.Any())
            .OrderByDescending(p => p.ModuleScores.Values.Average())
            .Take(count)
            .Join(_enrollments,
                  p => new { p.StudentId, p.CourseCode },
                  e => new { e.StudentId, e.CourseCode },
                  (p, e) => e)
            .ToList();
    }
}
}