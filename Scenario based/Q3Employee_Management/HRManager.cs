using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public class HRManager
    {
        private List<Employee> employees = new List<Employee>();
        private int idCounter = 1;

        public void AddEmployee(string name, string dept, double salary)
        {
            Employee emp = new Employee();

            emp.EmployeeId = "E" + idCounter.ToString("D3");
            emp.Name = name;
            emp.Department = dept;
            emp.Salary = salary;
            emp.JoiningDate = DateTime.Now;

            employees.Add(emp);
            idCounter++;
        }

        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> result =
                new SortedDictionary<string, List<Employee>>();

            foreach (Employee emp in employees)
            {
                if (!result.ContainsKey(emp.Department))
                {
                    result[emp.Department] = new List<Employee>();
                }

                result[emp.Department].Add(emp);
            }

            return result;
        }

        public double CalculateDepartmentSalary(string department)
        {
            double total = 0;

            foreach (Employee emp in employees)
            {
                if (emp.Department == department)
                {
                    total += emp.Salary;
                }
            }

            return total;
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> result = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (emp.JoiningDate > date)
                {
                    result.Add(emp);
                }
            }

            return result;
        }
    }
}
