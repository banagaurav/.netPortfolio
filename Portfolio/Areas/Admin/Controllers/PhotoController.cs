using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers;
[Area("Admin")]

public partial class PhotoController : Controller
{
    private readonly AppDbContext _db;
    public PhotoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult EditPhoto()
    {
        List<Photo> objPhotoList = _db.Photos.ToList();
        return View(objPhotoList);
    }

}

