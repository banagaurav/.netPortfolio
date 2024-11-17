using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

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
        List<Blog> objBlogList = _db.Blogs.ToList();
        List<Photo> objPhotoList = _db.Photos.ToList();
        return View(new Tuple<List<Blog>, List<Photo>>(objBlogList, objPhotoList));
    }


    public IActionResult Privacy()
    {
        return View();
    }
}
