using System;

namespace Q5
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }

        public Course Course { get; set; }
        public Instructor Instructor { get; set; }

        public Assignment(int id, string title, DateTime deadline, Course course, Instructor instructor)
        {
            AssignmentId = id;
            Title = title;
            Deadline = deadline;
            Course = course;
            Instructor = instructor;
        }

        public void Submit(DateTime submissionTime)
        {
            if (submissionTime > Deadline)
                throw new AssignmentDeadlineException("Assignment submitted after deadline.");

            Console.WriteLine("Assignment submitted successfully.");
        }
    }
}
