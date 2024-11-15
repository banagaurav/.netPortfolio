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
        List<Album> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }

    public IActionResult EditAlbum()
    {
        List<Album> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }

    public IActionResult Upload()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Upload(Album obj)
    {
        if (ModelState.IsValid)
        {
            _db.Photos.Add(obj);
            _db.SaveChanges();
        }
        return RedirectToAction("EditAlbum"); // for different controller ("action","Controller")
    }

}
