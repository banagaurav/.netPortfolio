using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class AboutMeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
