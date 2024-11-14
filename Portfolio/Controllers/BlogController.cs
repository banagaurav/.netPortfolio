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

        public IActionResult Create()
        {
            return View();
        }
    }
}
