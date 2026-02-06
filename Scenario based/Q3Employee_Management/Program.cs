using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main()
        {
            HRManager hr = new HRManager();

            while (true)
            {
                Console.WriteLine("\n===== EMPLOYEE MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees by Department");
                Console.WriteLine("3. Calculate Department Salary");
                Console.WriteLine("4. Show Recently Joined Employees");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine() ?? "";

                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine() ?? "";

                        Console.Write("Enter Salary: ");
                        if (!double.TryParse(Console.ReadLine(), out double salary))
                        {
                            Console.WriteLine("Invalid salary");
                            break;
                        }

                        hr.AddEmployee(name, dept, salary);
                        Console.WriteLine("Employee Added Successfully");
                        break;

                    case 2:
                        var grouped = hr.GroupEmployeesByDepartment();

                        foreach (var d in grouped)
                        {
                            Console.WriteLine("\nDepartment: " + d.Key);

                            foreach (Employee e in d.Value)
                            {
                                Console.WriteLine(
                                    e.EmployeeId + " | " +
                                    e.Name + " | " +
                                    e.Salary + " | " +
                                    e.JoiningDate.ToShortDateString());
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter Department: ");
                        string dep = Console.ReadLine() ?? "";

                        double total = hr.CalculateDepartmentSalary(dep);
                        Console.WriteLine("Total Salary: " + total);
                        break;

                    case 4:
                        Console.Write("Enter days (e.g., 5): ");
                        if (!int.TryParse(Console.ReadLine(), out int days))
                        {
                            Console.WriteLine("Invalid number");
                            break;
                        }

                        DateTime date = DateTime.Now.AddDays(-days);
                        var recent = hr.GetEmployeesJoinedAfter(date);

                        foreach (Employee e in recent)
                        {
                            Console.WriteLine(
                                e.EmployeeId + " | " +
                                e.Name + " | " +
                                e.Department + " | " +
                                e.JoiningDate.ToShortDateString());
                        }
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
