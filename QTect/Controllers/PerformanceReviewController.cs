using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QTect.Db;
using QTect.Models;

namespace QTect.Controllers
{
    public class PerformanceReviewController : Controller
    {
        private readonly AppDbContext _context;

        public PerformanceReviewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PerformanceReviews/Index
        public async Task<IActionResult> Index()
        {
            var reviews = await _context.PerformanceReviews
                                         .Include(pr => pr.Employee)
                                         .ToListAsync();
            return View(reviews);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.PerformanceReviews
                                        .Include(pr => pr.Employee)
                                        .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: PerformanceReviews/Create
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Employees.Where(a=> a.Deleted), "ID", "Name");
            return View();
        }

        // POST: PerformanceReviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID, ReviewDate, ReviewScore, ReviewNotes")] PerformanceReview performanceReview)
        {
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                _context.Add(performanceReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(_context.Employees.Where(a => a.Deleted), "ID", "Name");
            return View(performanceReview);
        }



        // GET: PerformanceReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.PerformanceReviews
                               .Include(pr => pr.Employee)
                               .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            ViewBag.Employees = new SelectList(_context.Employees.Where(a => a.Deleted), "ID", "Name");
            return View(review);
        }

        // POST: PerformanceReviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, EmployeeID, ReviewDate, ReviewScore, ReviewNotes")] PerformanceReview performanceReview)
        {
            if (id != performanceReview.ID)
            {
                return NotFound();
            }
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.PerformanceReviews.FindAsync(id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    entity.EmployeeID = performanceReview.EmployeeID;
                    entity.ReviewDate = performanceReview.ReviewDate;
                    entity.ReviewScore = performanceReview.ReviewScore;
                    entity.ReviewNotes = performanceReview.ReviewNotes;
       
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceReviewExists(performanceReview.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(_context.Employees.Where(a => a.Deleted), "ID", "Name");
            return View(performanceReview);
        }

        // GET: PerformanceReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.PerformanceReviews
                                        .Include(pr => pr.Employee)
                                        .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: PerformanceReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.PerformanceReviews.FindAsync(id);
            _context.PerformanceReviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformanceReviewExists(int id)
        {
            return _context.PerformanceReviews.Any(e => e.ID == id);
        }
    }
}

