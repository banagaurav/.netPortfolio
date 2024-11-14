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
            return RedirectToAction("Index"); // for different controller ("action","Controller")
        }
    }
}
