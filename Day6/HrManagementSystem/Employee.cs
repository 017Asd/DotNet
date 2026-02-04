using System;
namespace MainConstructor
{
    public class Employee:Activities
    {
        public int empid;
        public string name;

        protected string EmployeeDetails()
        {
            return $"{empid} {name}";
        }
        public string WorkTime()
        {
            return "Time is worktime";
        }
        public string Project()
        {
            return "I am working on this project";
        }
    }
}