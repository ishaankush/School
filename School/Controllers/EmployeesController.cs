using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly StudentsContext _context;

        public EmployeesController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var studentsContext = _context.Employees.Include(e => e.City).Include(e => e.Country).Include(e => e.EmployeeType).Include(e => e.State);
            return View(await studentsContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Country)
                .Include(e => e.EmployeeType)
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name");
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeTypes, "EmployeeTypeId", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,EmployeeTypeId,StateId,CityId,CreatedBy,CreatedOn,CountryId,Phone,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", employee.CountryId);
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeId", employee.EmployeeTypeId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", employee.StateId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", employee.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", employee.CountryId);
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeTypes, "EmployeeTypeId", "Name", employee.EmployeeTypeId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name", employee.StateId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,EmployeeTypeId,StateId,CityId,ModifiedBy,ModifiedOn,CreatedBy,CreatedOn,CountryId,Phone,Email")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   employee.CreatedOn = DateTime.Now;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", employee.CountryId);
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeId", employee.EmployeeTypeId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", employee.StateId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Country)
                .Include(e => e.EmployeeType)
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'StudentsContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
