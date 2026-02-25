using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class DepartmentController : Controller
	{
		private static List<Department> departments = new();
		private static List<Employee> employees = new();

		public IActionResult Index()
		{
			ViewBag.Departments = departments;
			ViewBag.Employees = employees;
			Console.WriteLine("Departments in Index: " + departments.Count);
			return View();
		}

		[HttpPost]
		public IActionResult AddDepartment(Department dept)
		{
			dept.Id = departments.Count + 1;
			departments.Add(dept);
			Console.WriteLine("Departments after add: " + departments.Count);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult AddEmployee(Employee emp)
		{
			emp.EmpId = employees.Count + 1;
			employees.Add(emp);

			return RedirectToAction("Index");
		}
		public static List<Department> GetDepartments()
		{
			return departments;
		}

		public static List<Employee> GetEmployees()
		{
			return employees;
		}
	}
}