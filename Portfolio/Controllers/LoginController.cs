using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

public class LoginController : Controller
{
    private readonly IUserService _userService; // Service for user authentication

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Authenticate the user (mock example; replace with real logic)
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user != null)
            {
                // Redirect based on role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (user.Role == "Client")
                {
                    return RedirectToAction("Index", "Home", new { area = "Client" });
                }
                else
                {
                    ModelState.AddModelError("", "User role not recognized.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }

        return View(model);
    }
}
