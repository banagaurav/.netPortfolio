using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]

public partial class ProjectController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
