using System.Diagnostics;
using EmpMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpMVC.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult Index()
		{
			return View("../EmpMVC/EmpaddView");
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
