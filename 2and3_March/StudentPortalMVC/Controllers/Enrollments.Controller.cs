using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Models;

namespace StudentPortalMVC.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public EnrollmentsController(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrollments);
        }

        public IActionResult Create()
        {
            ViewData["StudentId"] =
                new SelectList(_context.Students, "StudentId", "FullName");

            ViewData["CourseId"] =
                new SelectList(_context.Courses, "CourseId", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            enrollment.CreatedAt = DateTime.Now;

            var alreadyExists = await _context.Enrollments
                .AnyAsync(e =>
                    e.StudentId == enrollment.StudentId &&
                    e.CourseId == enrollment.CourseId);

            if (alreadyExists)
            {
                ModelState.AddModelError("", "This student is already enrolled in this course.");

                ViewData["StudentId"] =
                    new SelectList(_context.Students, "StudentId", "FullName", enrollment.StudentId);

                ViewData["CourseId"] =
                    new SelectList(_context.Courses, "CourseId", "Title", enrollment.CourseId);

                return View(enrollment);
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseId == enrollment.CourseId);

            if (course != null)
            {
                if (enrollment.PaidAmount <= 0)
                    enrollment.PaymentStatus = "Pending";
                else if (enrollment.PaidAmount < course.Fee)
                    enrollment.PaymentStatus = "Partial";
                else
                    enrollment.PaymentStatus = "Paid";
            }
            else
            {
                enrollment.PaymentStatus = "Pending";
            }

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // 🔥 REMOVE GET DELETE (No Delete.cshtml needed)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}