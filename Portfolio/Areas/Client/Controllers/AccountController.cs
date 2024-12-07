using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Areas.Client.Controllers
{
    [Area("Client")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Map RegisterViewModel to User model
            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password, // You should hash this before storing!
                Role = model.Role
            };

            // Save user using repository
            var success = await _userRepository.RegisterUser(newUser);

            if (success)
            {
                return RedirectToAction("Login", "Account", new { area = "Client" });
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return View(model);
        }
    }
}
