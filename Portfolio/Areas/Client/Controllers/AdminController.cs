
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]
public partial class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
