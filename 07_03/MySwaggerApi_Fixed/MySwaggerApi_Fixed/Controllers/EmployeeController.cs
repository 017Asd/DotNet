using Microsoft.AspNetCore.Mvc;
using MySwaggerApi.Data;
using MySwaggerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MySwaggerApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly AppDbContext _context;

		public EmployeeController(AppDbContext context)
		{
			_context = context;
		}

		// GET all employees
		[HttpGet]
		public IActionResult Get()
		{
			var employees = _context.Employees.ToList();
			return Ok(employees);
		}

		// GET employee by id
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var emp = _context.Employees.Find(id);

			if (emp == null)
				return NotFound("Employee not found");

			return Ok(emp);
		}

		// POST - Add employee
		[HttpPost]
		public IActionResult AddEmployee(Employee emp)
		{
			_context.Employees.Add(emp);
			_context.SaveChanges();

			return Ok(new
			{
				Message = "Employee added successfully",
				emp
			});
		}

		// PUT - Full update
		[HttpPut("{id}")]
		public IActionResult UpdateEmployee(int id, Employee updatedEmp)
		{
			var emp = _context.Employees.Find(id);

			if (emp == null)
				return NotFound("Employee not found");

			emp.Name = updatedEmp.Name;
			emp.Department = updatedEmp.Department;
			emp.Salary = updatedEmp.Salary;

			_context.SaveChanges();

			return Ok(new
			{
				Message = "Employee updated successfully",
				emp
			});
		}

		// DELETE
		[HttpDelete("{id}")]
		public IActionResult DeleteEmployee(int id)
		{
			var emp = _context.Employees.Find(id);

			if (emp == null)
				return NotFound("Employee not found");

			_context.Employees.Remove(emp);
			_context.SaveChanges();

			return Ok(new
			{
				Message = "Employee deleted successfully"
			});
		}
	}
}