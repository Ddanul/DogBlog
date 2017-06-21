using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dogblog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dogblog.Controllers
{
    public class HomeController : Controller
    {
        private DogContext _context;
 
    public HomeController(DogContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<string> errors = new List<string>();
            ViewBag.errors = errors;
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model, User NewUser)
        {
            if(ModelState.IsValid){
                User CurrUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                if( CurrUser == null){
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                    User currUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                    HttpContext.Session.SetInt32("CurrUserId", (int)currUser.UserId);
                    return RedirectToAction("Dashboard");
                }
                else{
                    List<string> errors = new List<string>();
                    ViewBag.errors = errors;
                    ViewBag.logerrors = "Email must be unique!";
                    return View("Index");
                }
            }
            else{
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password)
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.Email == Email);
            if(CurrUser != null && Password != null){
                if((string)CurrUser.Password == Password && (string)CurrUser.Email == Email){
                    HttpContext.Session.SetInt32("CurrUserId", (int)CurrUser.UserId);
                    return RedirectToAction("Dashboard");
                }
                else{
                    ViewBag.logerrors = "Invalid password/email combination!";
                    ViewBag.errors = new List<string>();
                    return View("Index");
                }
            }
            else{
                ViewBag.errors = new List<string>();
                ViewBag.logerrors = "Invalid password/email combination!!";
                return View("Index");
            }
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            List<User> AllUsers = _context.Users.OrderByDescending(user => user.CreatedAt).ToList();
            ViewBag.AllUsers = AllUsers;
            return View();
        }

        [HttpGet]
        [Route("Show/{UserId}")]
        public IActionResult Show(int UserId)
        {
            System.Console.WriteLine(UserId);
            User ThisPerson = _context.Users.SingleOrDefault(user => user.UserId == UserId);
            ViewBag.ThisPerson = ThisPerson;
            return View();
        }
    }
}
