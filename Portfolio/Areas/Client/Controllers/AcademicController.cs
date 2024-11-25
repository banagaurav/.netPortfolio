using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]

public partial class AcademicController : Controller
{
    private readonly AppDbContext _db;
    public AcademicController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Academic> objAcademicList = _db.Academics.ToList();
        return View(objAcademicList);
    }
}
