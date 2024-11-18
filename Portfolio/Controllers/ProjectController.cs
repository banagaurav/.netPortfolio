using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class ProjectController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
