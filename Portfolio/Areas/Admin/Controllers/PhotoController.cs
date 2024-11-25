using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers;
public class PhotoController : Controller
{
    private readonly AppDbContext _db;
    public PhotoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Photo> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }

    public IActionResult EditPhoto()
    {
        List<Photo> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }

    public IActionResult Upload()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Upload(Photo obj)
    {
        if (ModelState.IsValid)
        {
            _db.Photos.Add(obj);
            _db.SaveChanges();
        }
        return RedirectToAction("EditPhoto"); // for different controller ("action","Controller")
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Photo photoFromDb = _db.Photos.Find(id);
        if (photoFromDb == null)
        {
            return NotFound();
        }
        return View(photoFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Photo obj)
    {
        if (ModelState.IsValid)
        {
            _db.Photos.Update(obj);
            _db.SaveChanges();
        }
        return RedirectToAction("EditPhoto"); // for different controller ("action","Controller")
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Photo photoFromDb = _db.Photos.Find(id);
        if (photoFromDb == null)
        {
            return NotFound();
        }
        return View(photoFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Photo? obj = _db.Photos.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Photos.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("EditPhoto"); // for different controller ("action","Controller")
    }
}

