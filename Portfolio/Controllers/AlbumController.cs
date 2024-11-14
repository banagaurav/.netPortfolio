using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers;
public class AlbumController : Controller
{
    private readonly AppDbContext _db;
    public AlbumController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Album()
    {
        List<Album> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }
}
