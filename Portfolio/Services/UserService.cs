using Portfolio.Data;
using Portfolio.Models;
using System.Linq;

namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        // Constructor to inject the DbContext
        public UserService(AppDbContext db)
        {
            _db = db;

            // Check if there is already an admin in the database, if not, create one
            CreateDefaultAdmin();
        }

        // Ensure that an admin user exists in the database
        private void CreateDefaultAdmin()
        {
            // Check if an admin user already exists
            var adminExists = _db.Users.Any(u => u.Role == "Admin");

            if (!adminExists)
            {
                // Create a default admin user if none exists
                var adminUser = new User
                {
                    Username = "admin",
                    Password = "admin", // Password should be hashed in a real application!
                    Role = "Admin"
                };

                _db.Users.Add(adminUser);
                _db.SaveChanges(); // Commit the changes to the database
            }
        }
        // Authenticate a user by checking username and password
        public User Authenticate(string username, string password)
        {
            // Find the user from the database by username
            var user = _db.Users
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());


            // Check if the user exists and the password matches
            if (user != null && user.Password == password)
            {
                return user; // Valid user
            }

            return null; // Invalid username or password
        }

        // Register a new user with the "Client" role
        public void RegisterUser(string username, string password)
        {
            var newUser = new User
            {
                Username = username,
                Password = password, // Storing plain text for simplicity, but use hashing for security!
                Role = "Client" // Default role is "Client"
            };

            // Add the new user to the database
            _db.Users.Add(newUser);
            _db.SaveChanges(); // Commit the changes to the database
        }

        public User GetCurrentUser(string username)
        {
            // Fetch the user by username
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }

    }
}
