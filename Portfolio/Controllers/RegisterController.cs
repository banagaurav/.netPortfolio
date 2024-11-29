using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _db;
        public RegisterController(AppDbContext db)
        {
            _db = db;
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
                // Automatically assign the "Client" role
                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = "Client" // Role is always "Client"
                };

                // Save the new user to the database
                _db.Users.Add(newUser);
                _db.SaveChanges();

                // TODO: Save the newUser to the database or user store
                TempData["Message"] = "Registration successful as Client!";
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}
