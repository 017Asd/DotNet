using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Data;
using StudentPortalMVC.Models;

namespace StudentPortalMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> repository)
        {
            _repository = repository;
        } 

        // GET: Students
        public async Task<IActionResult> Index()
        {                                                                                                               
            var students = await _repository.GetAllAsync();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

		// POST: Students/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Student student)
		{
			// NAME VALIDATION
			if (string.IsNullOrWhiteSpace(student.FullName))
			{
				ModelState.AddModelError("FullName", "Name is required.");
			}

			// EMAIL VALIDATION
			if (string.IsNullOrWhiteSpace(student.Email))
			{
				ModelState.AddModelError("Email", "Email is required.");
			}
			else if (!System.Text.RegularExpressions.Regex.IsMatch(
				student.Email,
				@"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
			{
				ModelState.AddModelError("Email", "Enter a valid email address.");
			}

			// PHONE VALIDATION (10 DIGITS ONLY)
			if (string.IsNullOrWhiteSpace(student.Phone))
			{
				ModelState.AddModelError("Phone", "Phone number is required.");
			}
			else if (!System.Text.RegularExpressions.Regex.IsMatch(
				student.Phone,
				@"^\d{10}$"))
			{
				ModelState.AddModelError("Phone", "Phone number must be exactly 10 digits.");
			}

			// SAVE ONLY IF VALID
			if (ModelState.IsValid)
			{
				await _repository.AddAsync(student);
				await _repository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(student);
		}

		// GET: Students/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _repository.Update(student);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student != null)
            {
                _repository.Delete(student);
                await _repository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
//         public async Task<IActionResult> Search(string term)
// {
//     var students = await _repository.GetAllAsync();

//     if (!string.IsNullOrWhiteSpace(term))
//     {
//         term = term.ToLower();

//         students = students
//             .Where(s =>
//                 s.FullName.ToLower().Contains(term) ||
//                 s.Email.ToLower().Contains(term))
//             .ToList();
//     }

//     return PartialView("_StudentsTable", students);
// }
    public async Task<IActionResult> Search(string term,string status)
{
    var students = await _repository.GetAllAsync();

    if (!string.IsNullOrWhiteSpace(term))
    {
        term = term.ToLower();

        students = students
            .Where(s =>
                s.FullName.ToLower().Contains(term) ||
                s.Email.ToLower().Contains(term))
            .ToList();
    }
        if (!string.IsNullOrEmpty(status) && status != "All")
    {
        students = students.Where(s => s.Status == status);
    }


    return PartialView("_StudentsTable", students);
}
    }
}