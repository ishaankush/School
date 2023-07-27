using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    public class AccountsController : Controller
    {
        StudentsContext db = null;
        public AccountsController(StudentsContext _db)
        {
            db = _db;
        }

        //LOGIN
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            using (StudentsContext db = new StudentsContext())
            {
               var result = db.UserMasters.Where(x => x.UserId == user.Username && x.Password == user.Password);
                if (result.Count()!=0)
                {
                    HttpContext.Session.SetString("Username",user.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["msg"] = "Incorrect UserId/Password";
                }
            }
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }


        //REGISTER
        public IActionResult RegisterUser()
        {          
            return View();
        }



        [HttpPost]
        public IActionResult RegisterUser(UserMaster u)
        {
            try
            {             
                bool isUserIdExists = db.UserMasters.Any(x => x.UserId == u.UserId);
                if (isUserIdExists)
                {
                    ModelState.AddModelError("UserId", "User ID already exists");
                    return View();
                }


                u.Role = 9002;
                u.IsActive = true;
                db.UserMasters.Add(u);
                db.SaveChanges();

                ViewBag.Message = "User registered successfully login to continue";
            }
            catch
            {
                ViewBag.Message = "Unable to register, please try again";
                
            }

            return View();
        }

    }
}
