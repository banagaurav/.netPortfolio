using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class BlogsController : Controller
    {
        // GET: AcademicController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogDetails()
        {
            return View();
        }
    }
}
