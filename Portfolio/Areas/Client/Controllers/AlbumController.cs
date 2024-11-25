using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]

public partial class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
