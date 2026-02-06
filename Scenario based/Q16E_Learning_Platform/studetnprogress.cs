using System;
namespace Scenario{
public class StudentProgress
{
    public string StudentId { get; set; }
    public string CourseCode { get; set; }
    public Dictionary<string, double> ModuleScores { get; set; } = new();
    public DateTime LastAccessed { get; set; }
}
}