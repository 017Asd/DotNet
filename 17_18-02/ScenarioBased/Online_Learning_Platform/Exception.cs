using System;

namespace Q5
{
    public class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(string message) : base(message) { }
    }

    public class CourseCapacityExceededException : Exception
    {
        public CourseCapacityExceededException(string message) : base(message) { }
    }

    public class AssignmentDeadlineException : Exception
    {
        public AssignmentDeadlineException(string message) : base(message) { }
    }
}
