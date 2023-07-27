using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsContext _context;

        public StudentsController(StudentsContext context)
        {
            _context = context;
        }

        // Search Student
        public IActionResult SearchStudent()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            return View();
        }




        // POST-- SearchStudenta
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchStudent(string name, string city, string country, string state, DateTime? startDate, DateTime? endDate)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var students = _context.Students
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.State)
                .ToList();

            if (!string.IsNullOrWhiteSpace(name))
            {
                students = students.Where(s => s.Name.Contains(name)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                students = students.Where(s => s.City != null && s.City.Name.Contains(city)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                students = students.Where(s => s.Country != null && s.Country.Name.Contains(country)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                students = students.Where(s => s.State != null && s.State.Name.Contains(state)).ToList();
            }

            if (startDate != null && endDate != null)
            {
                students = students.Where(s => s.CreatedOn >= startDate && s.CreatedOn <= endDate).ToList();
            }

            return View(students);
        }



        // GET: Students
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var studentsContext = _context.Students.Include(s => s.City).Include(s => s.Country).Include(s => s.Cource).Include(s => s.State);
            return View(await studentsContext.ToListAsync());
        }

        // GET: Students/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.Cource)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name");
            ViewData["CourceId"] = new SelectList(_context.Courses, "CourseId", "Cource");
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name");
            return View();
        }

        // POST: Students/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Class,Dob,CityId,CountryId,StateId,CourceId,AdmissionDate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Student student)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (ModelState.IsValid)
            {
                student.CreatedOn = DateTime.Now;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", student.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", student.CountryId);
            ViewData["CourceId"] = new SelectList(_context.Courses, "CourseId", "CourseId", student.CourceId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", student.StateId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", student.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", student.CountryId);
            ViewData["CourceId"] = new SelectList(_context.Courses, "CourseId", "Cource", student.CourceId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "Name", student.StateId);
            return View(student);
        }

        // POST: Students/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Class,Dob,CityId,CountryId,StateId,CourceId,AdmissionDate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,FeePayment")] Student student)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    student.ModifiedOn = DateTime.Now;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", student.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", student.CountryId);
            ViewData["CourceId"] = new SelectList(_context.Courses, "CourseId", "CourseId", student.CourceId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", student.StateId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.Cource)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            if (_context.Students == null)
            {
                return Problem("Entity set 'StudentsContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //add cource 
        public IActionResult AddCource()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult AddCource(Course c)
        {   
            c.CreatedOn = DateTime.Now;
            _context.Add(c);
            _context.SaveChanges();
            return View();
        }

        //add city
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCity(City c)
        {
            c.CreatedOn = DateTime.Now;
            _context.Add(c);
            _context.SaveChanges();
            return View();
        }


        //add state
        public IActionResult AddState()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddState(State c)
        {
            c.CreatedOn = DateTime.Now;
            _context.Add(c);
            _context.SaveChanges();
            return View();
        }

        //add country
        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(Country c)
        {
            c.CreatedOn = DateTime.Now;
            _context.Add(c);
            _context.SaveChanges();
            return View();
        }



        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
