using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
