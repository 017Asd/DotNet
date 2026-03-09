using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Data;
using StudentPortalMVC.Models;

namespace StudentPortalMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> _repository;

        public CoursesController(IRepository<Course> repository)
        {
            _repository = repository;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _repository.GetAllAsync();
            return View(courses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _repository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(course);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _repository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _repository.Update(course);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _repository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            if (course != null)
            {
                _repository.Delete(course);
                await _repository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        
    }
}