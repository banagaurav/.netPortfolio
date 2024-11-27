using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Areas.Client.Controllers;

[Area("Client")]
public class LoginController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}