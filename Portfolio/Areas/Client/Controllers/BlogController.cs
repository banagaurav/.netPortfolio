using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]

public partial class BlogController : Controller
{
    private readonly AppDbContext _db;
    public BlogController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Blog> objBlogList = _db.Blogs.ToList();
        return View(objBlogList);
    }

}
