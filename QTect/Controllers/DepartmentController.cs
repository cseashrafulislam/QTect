using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QTect.Db;
using QTect.Models;
using System.Net;

namespace QTect.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Department/Index
        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .Include(d => d.Manager) 
                .ToListAsync();
            return View(departments);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
        // GET: Department/Create
        public IActionResult Create()
        {
            // Populate ViewBag.Employees with a list of employees
            ViewBag.Employees = new SelectList(_context.Employees, "ID", "Name");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName, ManagerID, Budget")] Department department)
        {
            ModelState.Remove("Manager");
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(_context.Employees, "Id", "Name", department.ManagerID);
            return View(department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewBag.Employees = _context.Employees.ToList();

            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, DepartmentName, ManagerID, Budget")] Department department)
        {
            if (id != department.ID)
            {
                return BadRequest(); // Ensure the ID matches the route parameter
            }
            ModelState.Remove("Manager");
            if (ModelState.IsValid)
            {
                try
                {
                    // Attach the entity to the context and mark it as modified
                    _context.Entry(department).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.ID))
                    {
                        return NotFound(); // Department doesn't exist
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index)); // Redirect to index after successful update
            }

            // Repopulate ViewBag.Employees to re-render the form
            ViewBag.Employees = new SelectList(_context.Employees, "ID", "Name", department.ManagerID);
            return View(department); // Return view with validation messages
        }


        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Manager) // Include Manager for more details (if applicable)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.ID == id);
        }
    }
}
