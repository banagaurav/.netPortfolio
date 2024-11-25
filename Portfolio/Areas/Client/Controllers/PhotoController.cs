using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Client.Controllers;
[Area("Client")]

public partial class PhotoController : Controller
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


}

