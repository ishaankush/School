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
    public class StaffsController : Controller
    {
        private readonly StudentsContext _context;

        public StaffsController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var studentsContext = _context.Staff.Include(s => s.City).Include(s => s.Country).Include(s => s.State);
            return View(await studentsContext.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,Name,StaffType,StateId,CountryId,CityId,CreatedBy,CreatedOn,Phone,Email")] Staff staff)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("Username") == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                staff.CreatedOn = DateTime.Now;
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", staff.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", staff.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", staff.StateId);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", staff.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", staff.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name", staff.StateId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,Name,StaffType,StateId,CountryId,CityId,CreatedBy,CreatedOn,Phone,Email")] Staff staff)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", staff.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", staff.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", staff.StateId);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (_context.Staff == null)
            {
                return Problem("Entity set 'StudentsContext.Staff'  is null.");
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
          return (_context.Staff?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
