using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModel;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {

        var homeVM = new HomeVM
        {
            Blogs = _db.Blogs.ToList(),
            Photos = _db.Photos.ToList()
        };
        // return View(new Tuple<List<Blog>, List<Photo>>(objBlogList, objPhotoList));
        return View(homeVM);
    }


    public IActionResult Privacy()
    {
        return View();
    }
}
