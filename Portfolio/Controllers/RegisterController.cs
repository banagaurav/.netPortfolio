using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService; // Use IUserService instead of direct DbContext

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        // Show the registration form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Process the registration form submission
        [HttpPost]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Call the UserService to register the new user
                _userService.RegisterUser(model.Username, model.Password);

                // Display a success message and redirect to login
                TempData["Message"] = "Registration successful as Client!";
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}
