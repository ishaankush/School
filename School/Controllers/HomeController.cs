﻿using Microsoft.AspNetCore.Mvc;
using School.Models;
using System.Diagnostics;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentsContext _context;

        public HomeController(ILogger<HomeController> logger, StudentsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           if(HttpContext.Session.GetString("Username") == null)
            {   
                return RedirectToAction("Login", "Accounts");
            }

            int studentCount = _context.Students.Count();
            int employeeCount = _context.Staff.Count();
            int courceCount  = _context.Courses.Count();
            int bookCount    = _context.Libraries.Count();
            ViewData["StudentCount"] = studentCount;
            ViewData["EmployeeCount"] = employeeCount;
            ViewData["CourceCount"] = courceCount;
            ViewData["BookCount"] = bookCount;

            //fee payment percentage          
            int studentsPaid = _context.Students.Count(s => s.FeePayment == true);        
            decimal percentagePaid = studentCount > 0 ? (decimal)studentsPaid / studentCount * 100 : 0;
            decimal percentagePaidFees = Math.Round(percentagePaid, 2);
            ViewData["PercentagePaidFees"] = percentagePaidFees;

            //chart logic
            var courseData = _context.Courses
        .Select(c => new { CourseName = c.Cource, StudentCount = c.Students.Count() })
        .ToList();
            ViewBag.MyList = courseData;

            List<NoticeBoard> notices = _context.NoticeBoards.ToList();

            ViewBag.Notices = notices;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddDetails()
        {
            if (HttpContext.Session.GetString("Username") != "admin")
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }

        public IActionResult Library()
        {
            if (HttpContext.Session.GetString("Username") != "admin")
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }

        //notice board Logic
        public IActionResult NoticeBoard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NoticeBoard(NoticeBoard n)
        {
            n.CreatedOn = DateTime.Now;
            _context.NoticeBoards.Add(n);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteNotice(int id)
        {
            if (HttpContext.Session.GetString("Username") != "admin")
            {
                return RedirectToAction("Login", "Accounts");
            }

            var noticeToDelete = _context.NoticeBoards.FirstOrDefault(n => n.Id == id);

            if (noticeToDelete != null)
            {
                _context.NoticeBoards.Remove(noticeToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index"); // Redirect to your desired action after deletion
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}