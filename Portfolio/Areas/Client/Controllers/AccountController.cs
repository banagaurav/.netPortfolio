using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Client";
                var result = await _userRepository.RegisterUser(user);
                if (result)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Username already exists.");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userRepository.LoginUser(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid credentials.");
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

