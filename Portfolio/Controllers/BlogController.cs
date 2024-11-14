using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Blog> objBlogList = _db.Blogs.ToList();
            return View(objBlogList);
        }

        public ActionResult BlogDetails()
        {
            return View();
        }

        //Edit BlogPage
        public IActionResult EditBlog()
        {
            List<Blog> objBlogList = _db.Blogs.ToList();
            return View(objBlogList);
        }

        // Add/Create/Post blog

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog obj)
        {
            if (ModelState.IsValid)
            {
                _db.Blogs.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditBlog"); // for different controller ("action","Controller")
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog blogFromDb = _db.Blogs.Find(id);
            if (blogFromDb == null)
            {
                return NotFound();
            }
            return View(blogFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Blog obj)
        {
            if (ModelState.IsValid)
            {
                _db.Blogs.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditBlog"); // for different controller ("action","Controller")
        }
    }
}
