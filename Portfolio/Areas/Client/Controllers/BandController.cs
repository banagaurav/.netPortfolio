using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]

public partial class BandController : Controller
{
    private readonly AppDbContext _db;
    public BandController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Band> objBandList = _db.Bands.ToList();
        return View(objBandList);
    }
}

