using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QTect.Db;
using QTect.Models;

namespace QTect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Include(e => e.Department).Where(a=> a.Deleted).ToListAsync();
            return View(employees);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.ID == id && m.Deleted);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["DID"] = new SelectList(_context.Departments, "ID", "DepartmentName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,Name,Email,Phone,Position,JoinDate,Status,DepartmentID")] Employee employee)
        {
            ModelState.Remove("Department");
            ModelState.Remove("ManagedDepartments");
            ModelState.Remove("PerformanceReviews");
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DID"] = new SelectList(_context.Departments, "ID", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DID"] = new SelectList(_context.Departments, "ID", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,Name,Email,Phone,Position,JoinDate,Status,DepartmentID")] Employee employee)
        {
       
            ModelState.Remove("Department");
            ModelState.Remove("ManagedDepartments");
            ModelState.Remove("PerformanceReviews");
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await _context.Employees.FindAsync(id);

                    if (entity == null)
                    {
                        return NotFound();
                    }

                    entity.Name = employee.Name;
                    entity.Email = employee.Email;
                    entity.Phone = employee.Phone;
                    entity.Position = employee.Position;
                    entity.JoinDate = employee.JoinDate;
                    entity.DepartmentID = employee.DepartmentID;
                    entity.Status = employee.Status;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }

                return RedirectToAction(nameof(Index));
            }

            var departments = _context.Departments.Select(d => new SelectListItem { Value = d.ID.ToString(), Text = d.DepartmentName }).ToList();
            ViewData["DID"] = departments;
            return View(employee);
        }


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.ID == id && m.Deleted);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Employees.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            entity.Status = "DeActive";
            entity.Deleted = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
