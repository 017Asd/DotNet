using Microsoft.AspNetCore.Mvc;
using Employee.Data.Models;
using Employee.Data.Repositories;

using EmployeeModel = Employee.Data.Models.Employee;

namespace Employee.MVC.Controllers
{
public class EmployeeController : Controller
{
private readonly IRepository<EmployeeModel> _repository;


    public EmployeeController(IRepository<EmployeeModel> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _repository.GetAll();
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeModel employee)
    {
        if (ModelState.IsValid)
        {
            await _repository.Add(employee);
            await _repository.Save();

            return RedirectToAction(nameof(Index));
        }

        return View(employee);
    }
}

}
