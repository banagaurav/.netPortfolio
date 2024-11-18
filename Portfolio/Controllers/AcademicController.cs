using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class AcademicController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
