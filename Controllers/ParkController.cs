using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dogblog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace dogblog.Controllers
{
    public class ParkController : Controller
    {
        private DogContext _context;
 
    public ParkController(DogContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("Parks")]
        public IActionResult Parks()
        {
            List<string> errors = new List<string>();
            ViewBag.errors = errors;
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            List<Park> allParks = _context.Parks.Include(rev => rev.Reviews).ToList();
            ViewBag.allParks = allParks;
            return View();
        }

        [HttpPost]
        [Route("AddPark")]
        public IActionResult AddPark(ParkViewModel model, Park newPark)
        {
            if(ModelState.IsValid){
                _context.Parks.Add(newPark);
                _context.SaveChanges();
                return RedirectToAction("Parks");
            }
            else{
                ViewBag.errors = ModelState.Values;
                return View("Parks");
            }
        }
            
        [HttpGet]
        [Route("ParkShow/{ParkId}")]
        public IActionResult ParkShow(int ParkId)
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            Park thisPark = _context.Parks.Include(rev => rev.Reviews).ThenInclude(use => use.User).SingleOrDefault(park => park.ParkId == ParkId);
            ViewBag.thisPark = thisPark;
            return View();
        } 

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(Review newReview)
        {
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return RedirectToAction("Parks");
        }
    }
}

