using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Album photoFromDb = _db.Photos.Find(id);
        if (photoFromDb == null)
        {
            return NotFound();
        }
        return View(photoFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Album obj)
    {
        if (ModelState.IsValid)
        {
            _db.Photos.Update(obj);
            _db.SaveChanges();
        }
        return RedirectToAction("EditAlbum"); // for different controller ("action","Controller")
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Album photoFromDb = _db.Photos.Find(id);
        if (photoFromDb == null)
        {
            return NotFound();
        }
        return View(photoFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Album? obj = _db.Photos.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Photos.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("EditAlbum"); // for different controller ("action","Controller")
    }
}

