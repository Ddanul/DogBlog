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
    public class BlogController : Controller
    {
        private DogContext _context;
 
    public BlogController(DogContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("Blog")]
        public IActionResult Blog()
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            List<Blog> AllBlogs= _context.Blogs.Include(com => com.Comments).ThenInclude(use => use.User).ToList();
            ViewBag.AllPosts = AllBlogs;
            return View();
        }

        [HttpGet]
        [Route("Show/{BlogId}")]
        public IActionResult Show(int BlogId)
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            Blog thisBlog = _context.Blogs.Include(com => com.Comments).ThenInclude(use => use.User).SingleOrDefault(blog => blog.BlogId == BlogId);
            ViewBag.thisBlog = thisBlog;
            return View();
        }

        [HttpGet]
        [Route("addBlog")]
        public IActionResult AddBlog()
        {
            User CurrUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrUser = CurrUser;
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public IActionResult CreateBlog(Blog newBlog)
        {
            Blog MyBlog = new Blog{
                    UserId = newBlog.UserId,
                    Title = newBlog.Title,
                    Content = newBlog.Content
                };
                _context.Blogs.Add(MyBlog);
                _context.SaveChanges();

                return RedirectToAction("Blog");
        }

        [HttpPost]
        [Route("AddComment")]
        public IActionResult AddComment(Comment newComment)
        {
            Comment addComment = new Comment{
                    UserId = newComment.UserId,
                    Text = newComment.Text,
                    BlogId = newComment.BlogId
                };
                _context.Comments.Add(addComment);
                _context.SaveChanges();

                return RedirectToAction("Blog");
        }
    }
}