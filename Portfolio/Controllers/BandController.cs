using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class BandController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
